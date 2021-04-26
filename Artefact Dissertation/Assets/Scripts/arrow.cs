using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{


    [SerializeField] private float speed;

    private float time;

    void Start()
    {
        time = Time.time;
    }

    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        if(Time.time-time>=225)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
