using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using UnityEngine.AI;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move the GameObject to a random position in an area using a NavMeshAgent.
    /// </summary>
    [Action("Navigation/MoveToAvoidRandom")]
    [Help("Gets a random position from a given area and moves the game object to that point by using a NavMeshAgent")]
    public class MoveToAvoidRandom : GOAction
    {
        private UnityEngine.AI.NavMeshAgent navAgent;

        ///<value>Input game object Parameter that must have a BoxCollider or SphereColider, which will determine the area from which the position is extracted.</value>
        [InParam("area")]
        [Help("game object that must have a BoxCollider or SphereColider, which will determine the area from which the position is extracted")]
        public GameObject area;

        ///<value>Input target game object towards this game object will be moved Parameter.</value>
        [InParam("target")]
        [Help("Target game object towards this game object will be moved")]
        public GameObject target;

        ///<value>Input maximun distance Parameter to consider that the target is close.</value>
        [InParam("closeDistance")]
        [Help("The maximun distance to consider that the target is close")]
        public float closeDistance;

        private int count = 0;
        private Vector3 previousPosition;

        /// <summary>Initialization Method of MoveToRandomPosition.</summary>
        /// <remarks>Check if there is a NavMeshAgent to assign it one by default and assign it
        /// to the NavMeshAgent the destination a random position calculated with <see cref="getRandomPosition()"/> </remarks>
        public override void OnStart()
        {
            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            previousPosition = navAgent.transform.position;
            if (navAgent == null)
            {
                Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
                navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
            }
            getRandomPosition();
            navAgent.velocity = Vector3.zero;

            #if UNITY_5_6_OR_NEWER
                navAgent.isStopped = false;
            #else
                navAgent.Resume();
            #endif
        }
        /// <summary>Method of Update of MoveToRandomPosition </summary>
        /// <remarks>Check the status of the task, if it has traveled the road or is close to the goal it is completed
        /// and otherwise it will remain in operation.</remarks>
        public override TaskStatus OnUpdate()
        {

            DrawNavMeshPath.path = navAgent.path.corners;
            DrawNavMeshPath.isChasingPlayer = false;
            if (count++ % 10 == 0 && CheckIfPathIntersectsPlayer(navAgent.path))
            {
                navAgent.velocity = Vector3.zero;
                getRandomPosition();
                previousPosition = navAgent.transform.position;
                DrawNavMeshPath.path = navAgent.path.corners;
                DrawNavMeshPath.isChasingPlayer = false;
            }
            if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }

        private Vector3 getRandomPosition()
        {
            
            Vector3 randomPosition;
            BoxCollider boxCollider = area != null ? area.GetComponent<BoxCollider>() : null;
            if (boxCollider != null)
            {
                NavMeshPath path = new NavMeshPath();
                int numIterations = 0;
                do
                {
                    do
                    {
                        randomPosition = new Vector3(UnityEngine.Random.Range(area.transform.position.x - area.transform.localScale.x * boxCollider.size.x * 0.5f,
                                                      area.transform.position.x + area.transform.localScale.x * boxCollider.size.x * 0.5f),
                             UnityEngine.Random.Range(area.transform.position.y - area.transform.localScale.y * boxCollider.size.y * 0.5f,
                                                      area.transform.position.y + area.transform.localScale.y * boxCollider.size.y * 0.5f));
                    }
                    while (Vector2.Distance(randomPosition, target.transform.position) < closeDistance);

                    navAgent.CalculatePath(randomPosition, path);
                    Debug.Log("Iteration #" + numIterations + ": " + path.corners.Length + "corners");

                    numIterations++;
                }
                while (numIterations < 10 && CheckIfPathIntersectsPlayer(path));
                if (numIterations >= 10)
                {
                    navAgent.SetDestination(navAgent.transform.position);
                }
                navAgent.SetPath(path);
                return randomPosition;
            }
            else
            {
                SphereCollider sphereCollider = area != null ? area.GetComponent<SphereCollider>() : null;
                if (sphereCollider != null)
                {
                    float distance = UnityEngine.Random.Range(-sphereCollider.radius, area.transform.localScale.x * sphereCollider.radius);
                    float angle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
                    return new Vector3(area.transform.position.x + distance * Mathf.Cos(angle),
                                       area.transform.position.y,
                                       area.transform.position.z + distance * Mathf.Sin(angle));
                }
                else
                {
                    return gameObject.transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f));
                }
            }
        }

        public bool CheckIfPathIntersectsPlayer(NavMeshPath path)
        {
            for (int i = 1; i < path.corners.Length; i++)
            {
                Vector3 dir = (path.corners[i] - path.corners[i - 1]);
                RaycastHit2D hit = Physics2D.CircleCast(path.corners[i - 1] + new Vector3(0, 0.1f, 0), 0.25f, dir, Vector2.Distance(path.corners[i - 1], path.corners[i]));
                // Prev corner is farther from target than the subsequent and the subsequent is close to target, reset
                if (hit && hit.collider.gameObject == target)
                //((Vector2.Distance(path.corners[i - 1], target.transform.position) > Vector2.Distance(path.corners[i], target.transform.position)
                //&& Vector2.Distance(path.corners[i], target.transform.position) < closeDistance / 2)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>Abort method of MoveToRandomPosition </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {
            #if UNITY_5_6_OR_NEWER
                navAgent.isStopped = true;
            #else
                navAgent.Stop();
            #endif
        }
    }
}
