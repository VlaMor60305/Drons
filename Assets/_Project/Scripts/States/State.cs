using UnityEngine;

public abstract class State : ScriptableObject
{
    public abstract void EnterState(Dron owner);
    public abstract void UpdateState(Dron owner);
    public abstract void ExitState(Dron owner);
    public abstract void OnStateComplete(Dron owner);
}
