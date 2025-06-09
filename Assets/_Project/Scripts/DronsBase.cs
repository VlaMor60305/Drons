using System.Collections.Generic;
using UnityEngine;

public class DronsBase : MonoBehaviour
{
    public int resourcesCount { get; private set; } = 0;

    [field: SerializeField] public Transform[] spawners {  get; private set; }
    [field: SerializeField] public List<Dron> activeDrons { get; private set; } = new List<Dron>();
    [SerializeField] private Dron _dronPrefab;
    
    public int dronCount = 1;

    void Start()
    {
        ChangeDronsCount(3);
    }

    void Update()
    {
        
    }

    public void ChangeResources(int delta)
    {
        resourcesCount += delta;
    }

    public void ChangeDronsCount(int delta)
    {
        dronCount += delta;
        dronCount = Mathf.Clamp(dronCount, 0, spawners.Length);
        UpdateDronCount();
    }
    void UpdateDronCount()
    {
        while (activeDrons.Count < dronCount)
        {
            SpawnDrone();
        }
        while (activeDrons.Count > dronCount)
        {
            DespawnDron();
        }
    }
    void SpawnDrone()
    {
        GameObject newDron = Instantiate(_dronPrefab.gameObject, spawners[activeDrons.Count].position, Quaternion.identity);
        Dron cachedDron = newDron.GetComponent<Dron>();
        activeDrons.Add(cachedDron);
        cachedDron.SetSpawnPoint(spawners[activeDrons.Count-1]);
        cachedDron.SetDronBase(this);
    }

    void DespawnDron()
    {
        Dron cachedDron = activeDrons[activeDrons.Count - 1];
        activeDrons.Remove(cachedDron);
        Destroy(cachedDron.gameObject);
    }
}
