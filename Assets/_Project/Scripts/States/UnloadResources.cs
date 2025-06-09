using UnityEngine;

[CreateAssetMenu(fileName = "Unload Resources State", menuName = "States / Dron / Unload Resources State")]
public class UnloadResources : State
{
    public override void EnterState(Dron owner)
    {
        OnStateComplete(owner);
    }

    public override void UpdateState(Dron owner)
    {

    }
    public override void ExitState(Dron owner)
    {

    }

    public override void OnStateComplete(Dron owner)
    {
        owner.dronsBase.ChangeResources(1);
        owner.PlayUnloadEffect();
        owner.OnStateComplete(this);
    }
}
