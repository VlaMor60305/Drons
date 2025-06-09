using UnityEngine;

public class Resource : MonoBehaviour
{
    public Dron digger { get; private set; }
    public Transform cachedTransform { get; private set; }

    private void Awake()
    {
        cachedTransform = transform;
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.activeResources.Remove(this);
    }

    public void SetDigger(Dron digger)
    {
        this.digger = digger; 
    }
}
