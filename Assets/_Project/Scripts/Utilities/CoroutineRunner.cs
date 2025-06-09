using System.Collections;
using UnityEngine;

public static class CoroutineRunner
{
    public static void RunCoroutine(MonoBehaviour owner, IEnumerator coroutine)
    {
        owner.StartCoroutine(coroutine);
    }
}
