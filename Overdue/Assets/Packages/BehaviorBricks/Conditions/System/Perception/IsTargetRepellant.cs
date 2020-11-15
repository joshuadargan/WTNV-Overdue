using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("Perception/IsTargetRepellant")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class IsTargetRepellant : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        [InParam("target")]
        [Help("Target to check if repellant")]
        public GameObject target;

        /// <summary>
        /// Checks whether a target is close depending on a given distance,
        /// calculates the magnitude between the gameobject and the target and then compares with the given distance.
        /// </summary>
        /// <returns>True if the magnitude between the gameobject and de target is lower that the given distance.</returns>
        public override bool Check()
		{
            Vector3 dir = (target.transform.position - gameObject.transform.position);
            if (dir.sqrMagnitude > 20)
            {
                if (dir.sqrMagnitude > 10)
                {
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Closed);
                }
                else
                {
                    StealthUIIndicator.SetUIEyeState(StealthUIIndicator.EyeState.Ajar);
                }
            }
            return target.GetComponent<RepllentPickup>().IsRepellant();
		}
    }
}