using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Centurion : agent
{
    
    public Formation formation;
   // [SerializeField] private Animator animator;
    private bool testudo_stance;
    public float angle;
    public Animator animator;
    [SerializeField] private NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        formation = Formation.Close_Order;
        testudo_stance = false;
        angle = gameObject.transform.eulerAngles.y;
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (formation == Formation.Testudo)
        {
            animator.SetBool("testudo_centurion", true);

            transform.localScale = new Vector3(transform.localScale.x, 2.5f, transform.localScale.z);
        }
        else
        {
            animator.SetBool("testudo_centurion", false);
            transform.localScale = new Vector3(transform.localScale.x, 4f, transform.localScale.z);
        }
        angle = gameObject.transform.eulerAngles.y;
        if(formation==Formation.Open_Order)
            Agent.speed = 10f;

        if (formation == Formation.Close_Order)
            Agent.speed = 5f;

        if (formation == Formation.Testudo)
            Agent.speed = 1f;

        if (formation == Formation.Orbis)
            Agent.speed = 1f;

        if (formation == Formation.Cuneus)
            Agent.speed = 10f;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "barbarian_sword")
    //    {
    //        Destroy(gameObject);

    //    }

    //    if (collision.gameObject.tag == "arrow")
    //    {
    //        Destroy(gameObject);

    //    }
    //}



    public float GetAngle()
    {
        return angle;
    }
}
