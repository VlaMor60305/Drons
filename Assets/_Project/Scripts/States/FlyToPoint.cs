using UnityEngine;
using UnityEngine.UIElements.Experimental;


[CreateAssetMenu (fileName = "Fly To Resource State", menuName = "States / Dron / Fly To Resource State")]
public class FlyToPoint : State
{
    public float speedFlying = 5f;
    public float rotationSpeed = 90f;
    public float rayLength = 1f;
    public LayerMask obstacles;

    public float distanceToStop = 0.5f;

    public bool isVisualizePath = false;
    public override void EnterState(Dron owner)
    {

    }

    public override void UpdateState(Dron owner)
    {
        if (owner.pathVisualiser != null && isVisualizePath == true)
        {
            owner.pathVisualiser.SetPosition(0, owner.cachedTransform.position);
            owner.pathVisualiser.SetPosition(1, owner.target.position);
        }
        else
        {
            owner.pathVisualiser.SetPosition(0, Vector3.zero);
            owner.pathVisualiser.SetPosition(1, Vector3.zero);
        }
        MoveToPoint(owner);
    }
    public override void ExitState(Dron owner)
    {
        owner.pathVisualiser.SetPosition(0, Vector3.zero);
        owner.pathVisualiser.SetPosition(1, Vector3.zero);
    }

    public override void OnStateComplete(Dron owner)
    {
        owner.OnStateComplete(this);
    }

    void MoveToPoint(Dron owner)
    {


        if (IsObstacleForward(owner) == null)
        {

            owner.cachedTransform.position = Vector3.MoveTowards(owner.cachedTransform.position, owner.target.position, speedFlying * Time.deltaTime);
            owner.cachedTransform.rotation = Quaternion.Lerp(owner.cachedTransform.rotation, Quaternion.LookRotation((owner.target.position - owner.cachedTransform.position).normalized), rotationSpeed * Time.deltaTime);

            if (Vector3.Distance(owner.cachedTransform.position, owner.target.position) <= distanceToStop)
            {
                OnStateComplete(owner);
            }
        }
        else
        {
            int direction = IsObstacleForward(owner).transform.position.y > owner.cachedTransform.position.y ? -1 : 1;
            owner.cachedTransform.Translate(owner.cachedTransform.up * direction * speedFlying * Time.deltaTime, Space.Self);
        }
    }

    public Transform IsObstacleForward(Dron owner)
    {
        RaycastHit hit;
        
        if(Physics.Raycast(owner.cachedTransform.position, owner.cachedTransform.forward, out hit, rayLength, obstacles))
        {
            return hit.transform;
        }

        return null;
    }

}
