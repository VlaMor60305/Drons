using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Dig Resource State", menuName = "States / Dron / Dig Resource State")]
public class DigResource : State
{
    public float diggingTime = 2f;

    public override void EnterState(Dron owner)
    {
        CoroutineRunner.RunCoroutine(owner, DelayDiggingResource(owner));
    }

    public override void UpdateState(Dron owner)
    {

    }
    public override void ExitState(Dron owner)
    {

    }

    public override void OnStateComplete(Dron owner)
    {
        owner.OnStateComplete(this);
    }

    IEnumerator DelayDiggingResource(Dron owner)
    {
        yield return new WaitForSeconds(diggingTime);
        if (owner.resource != null)
        {
            Destroy(owner.resource.gameObject);
        }
        OnStateComplete(owner);
    }
}
