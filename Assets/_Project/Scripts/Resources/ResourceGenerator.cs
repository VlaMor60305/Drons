using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    

    public Resource resourcePrefab;

    [Header("Generator Settings")]
    public int maxResourcesCount = 20;
    public float spawnInterval = 0.1f;
    

    [Header("Spawn Area")]
    public float width = 500;
    public float height = 500;
    public float depth = 500;
    
    void Start()
    {
        

        FillResources();

        StartCoroutine(CreatingResources());
    }

    void FillResources()
    {
        for(int i = 0; i < maxResourcesCount; i++)
        {
            SpawnResource();
        }
    }

    IEnumerator CreatingResources()
    {
        while(true)
        {
            if(ResourceManager.Instance.activeResources.Count < maxResourcesCount)
            {
                SpawnResource();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnResource()
    {
        Resource newResource = Instantiate(resourcePrefab, new Vector3(Random.Range(-width / 2, width / 2), Random.Range(-height / 2, height / 2), Random.Range(-depth / 2, depth / 2)), Quaternion.identity).GetComponent<Resource>();
        ResourceManager.Instance.activeResources.Add(newResource);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, depth));
    }
}
