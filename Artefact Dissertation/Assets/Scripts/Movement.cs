using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    NavMeshAgent agent;
    private Vector3 startPosition;
    private Vector3 destination;

    private float angle;
    private RaycastHit hit;


    [SerializeField] private Centurion centurion;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                destination = hit.point;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - startPosition;

            if (mouseDelta.sqrMagnitude < 0.1f)
            {
                return; // don't do tiny rotations.
            }

            angle = Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg;
            if (angle < 0) angle += 360;

            Debug.Log(angle);

            
        }



        if (Vector3.Distance(transform.position, destination) <= 4.1)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                      angle,
                                                      transform.localEulerAngles.z);

            centurion.angle = angle;
            agent.SetDestination(transform.position);
        }
       
    }
}
