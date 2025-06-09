using UnityEngine;

public class Dron : MonoBehaviour
{
    [Header("States")]
    [field: SerializeField] public State currentState { get; private set; }
    [SerializeField] private State findPointState;
    [SerializeField] private State flyToPointState;
    [SerializeField] private State digAtPointState;
    [SerializeField] private State flyBackState;
    [SerializeField] private State unloadResourcesState;

    [Header("Visual")]
    public ParticleSystem unloadEffect;
    public LineRenderer pathVisualiser;
    [field: SerializeField] public DronsBase dronsBase { get; private set; }
    [field: SerializeField] public Transform spawnPoint { get; private set; }
    public Transform target { get; private set; }
    public Resource resource { get; private set; }

    //Cached Data
    public Transform cachedTransform { get; private set; }

    void Start()
    {
        cachedTransform = transform;

        currentState = findPointState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);   
    }

    public void ChangeState(State newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public void OnStateComplete(State state)
    {
        // It's possible to create more elegant variant , BUT - it'll take a lot of time. So that's why I'm using if/else here
        if (state == findPointState)
        {
            ChangeState(flyToPointState);
        }
        else if(state == flyToPointState)
        {
            if (resource != null)
            {
                ChangeState(digAtPointState);
            }
            else
            {
                ChangeState(unloadResourcesState);
            }
        }
        else if (state == digAtPointState)
        {
            SetTarget(spawnPoint);
            ChangeState(flyBackState);
        }
        else if (state == flyBackState)
        {
            ChangeState(unloadResourcesState);
        }
        else if (state == unloadResourcesState)
        {
            ChangeState(findPointState);
        }
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
    public void SetDronBase(DronsBase newDronsBase)
    {
        dronsBase = newDronsBase;
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    public void SetResource(Resource newResources)
    {
        resource = newResources;
    }

    public void PlayUnloadEffect()
    {
        if(unloadEffect != null)
        {
            unloadEffect.Play();
        }
    }
}
