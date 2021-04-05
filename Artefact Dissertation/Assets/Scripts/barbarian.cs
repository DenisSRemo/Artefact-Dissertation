using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class barbarian : MonoBehaviour
{

   [SerializeField] private Transform target;

    public float speed;


    [SerializeField] private bool charge;
    [SerializeField] private bool advance;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(advance)
        {
            speed = 1f;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
        
        if(charge)
        {
            speed = 1f;
            transform.position += transform.forward * Time.deltaTime * speed;
        }
           

    }





   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "legionary_sword")
        {
            Destroy(gameObject);

        }

       
    }


}
