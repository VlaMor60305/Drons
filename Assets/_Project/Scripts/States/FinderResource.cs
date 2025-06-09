using UnityEngine;

[CreateAssetMenu(fileName = "Finder Resource State", menuName = "States / Dron / Finder Resource State")]
public class FinderResource : State
{

    Resource closestResource = null;

    public override void EnterState(Dron owner)
    {
        FindClosestResource(owner);
    }
    
    public override void UpdateState(Dron owner)
    {
        if (closestResource != null)
            return;

        FindClosestResource(owner);
    }
    public override void ExitState(Dron owner)
    {

    }

    public override void OnStateComplete(Dron owner)
    {
        closestResource.SetDigger(owner);
        owner.SetResource(closestResource);
        owner.SetTarget(closestResource.cachedTransform);
        owner.OnStateComplete(this);
    }


    void FindClosestResource(Dron owner)
    {
        closestResource = ResourceManager.Instance.GetClosestResource(owner);

        if (closestResource != null)
        {
            OnStateComplete(owner);
        }
    }
}
