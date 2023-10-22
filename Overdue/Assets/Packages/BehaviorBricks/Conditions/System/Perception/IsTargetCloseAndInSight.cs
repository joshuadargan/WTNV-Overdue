using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance and angle.
    [Condition("Perception/IsTargetCloseAndInSight")]
    [Help("Checks whether a target is close and in sight depending on a given distance and an angle")]
    public class IsTargetCloseAndInSight : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance and angle.</value>
        [InParam("target")]
        [Help("Target to check the distance and angle")]
        public GameObject target;

        ///<value>Input view angle parameter to consider that the target is in sight.value>
        [InParam("angle")]
        [Help("The view angle to consider that the target is in sight")]
        public float angle;

        ///<value>Input maximun distance Parameter to consider that the target is close.</value>
        [InParam("closeDistance")]
        [Help("The maximun distance to consider that the target is close")]
        public float closeDistance;

        private Vector3 currentPosition;
        private Vector3 previousPosition;
        private double timeSinceLastSighting = float.MaxValue;
        private int updateCount = 0;
        private PlayerMovement movement;
        private const double HIDE_TIME = 1;
        /// <summary>
        /// Checks whether a target is close and in sight depending on a given distance and an angle, 
        /// First calculates the magnitude between the gameobject and the target and then compares with the given distance, then
        /// casting a raycast to the target and then compare the angle of forward vector with de raycast direction.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance
        /// and if the angle of forward vector with the  raycast direction is lower than the given angle, false therwase.</returns>
        public override bool Check()
        {
            if (!movement)
            {
                movement = target.GetComponent<PlayerMovement>();
            }
            timeSinceLastSighting += Time.deltaTime;
            ++updateCount;
            if (currentPosition == null)
            {
                currentPosition = this.gameObject.transform.position;
                previousPosition = this.gameObject.transform.position;
            }
            else if (updateCount % 5 == 0)
            {
                previousPosition = currentPosition;
                currentPosition = this.gameObject.transform.position;
            }

            LibrarianBehavior behavior = this.gameObject.GetComponent<LibrarianBehavior>();
            if (CheatCodeInput.debugMode)
                Debug.DrawLine(currentPosition, target.transform.position, Color.green);
            Vector3 dir = (target.transform.position - currentPosition);
            // If not suspicious and far away
            if (!behavior.IsSuspicious() && dir.magnitude > closeDistance * 3)
            { 
                return false;
            }
            RaycastHit2D hit = Physics2D.Raycast(currentPosition + new Vector3(0, 0.1f, 0), dir, closeDistance+1);

            if (hit || behavior.IsSuspicious())
            {
                if (timeSinceLastSighting > HIDE_TIME && movement && movement.IsHiddenUnderTable)       //determines if the librarians should exit search mode
                {
                    behavior.SetSuspicion(0);
                }
                // If in range and in visible area
                if (hit && hit.collider.gameObject == target && Vector3.Angle(dir, currentPosition - previousPosition) < angle * 0.5f)
                {
                    
                    if (!behavior.IsSuspicious() && movement.IsHiddenUnderTable)
                    {
                        StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Ajar);
                        return false;
                    }
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Open);
                    behavior.SetSuspicion(5);
                    timeSinceLastSighting = 0;
                }
                else
                {
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Ajar);
                }

                return behavior.IsSuspicious();
            }
            else
            {
                if (Vector2.Distance(currentPosition, target.transform.position) > closeDistance * 2)
                {
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Closed);
                }
                else
                {
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Ajar);
                }
            }

            return false;
		}
    }
}