using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Legionary : agent
{
   
    [SerializeField] private Centurion centurion;
    [SerializeField] private float Rank;
    [SerializeField] private float Column;
    public Vector3 pos;
    public float distanceOpenOrder=10f;



    NavMeshAgent agent;






    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pos = centurion.transform.position;
        pos.x = pos.x + Column * distanceOpenOrder;
        pos.z = pos.z + Rank * -distanceOpenOrder;
        agent.destination = pos;
       
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pos = hit.point;
                pos.x = pos.x + Column * distanceOpenOrder;
                pos.z = pos.z + Rank * -distanceOpenOrder;
                agent.destination = pos;
            }
            
        }

    }

    protected void Open_Order()
    {

    }
    protected void Close_Order()
    {

    }
    protected void Testudo()
    {

    }
    protected void Orbis()
    {

    }

    protected void Cuneus()
    {

    }
}
