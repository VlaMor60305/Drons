using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    public Vector3 towards;


    public bool isRandomSpeed;
    private Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        if(isRandomSpeed == true)
        {
            speed += Random.Range(-speed * 0.3f, speed * 0.3f);
        }
        myTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(towards * speed * Time.deltaTime);
    }
}
