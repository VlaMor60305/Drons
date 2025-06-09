using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    public List<Resource> activeResources { get; private set; } = new List<Resource>();


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Resource GetClosestResource(Dron owner)
    {
        Resource closestResource = null;

        foreach (Resource resource in activeResources)
        {
            if (closestResource == null)
            {
                if (resource.digger == null)
                {
                    closestResource = resource;
                }
            }
            else if (resource.digger == null)
            {
                if (Vector3.SqrMagnitude(closestResource.cachedTransform.position - owner.cachedTransform.position) > Vector3.SqrMagnitude(resource.cachedTransform.position - owner.cachedTransform.position))
                {
                    closestResource = resource;
                }
            }
        }

        if (closestResource != null)
        {
            closestResource.SetDigger(owner);
            return closestResource;
        }
        else
        {
            return null;
        }
    }
}

