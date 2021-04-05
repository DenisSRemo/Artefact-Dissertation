using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Century : MonoBehaviour
{



    [SerializeField] private Centurion centurion;
    [SerializeField] private List<Legionary> legionaries;


    NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<legionaries.Count;i++)
        {
            
            legionaries[i].Close_Order();
        }


        Agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Open_Order()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation=agent.Formation.Open_Order;
            legionaries[i].forming = true;
        }
        centurion.formation = agent.Formation.Open_Order;
        Agent.speed = 10f;
    }

    public void Close_Order()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Close_Order;
            legionaries[i].forming = true;
        }
        centurion.formation = agent.Formation.Close_Order ;
        Agent.speed = 5f;
    }

    public void Testudo()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Testudo;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Testudo;
        Agent.speed = 1f;
    }


    public void Orbis()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Orbis;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Orbis;
        Agent.speed = 1f;
    }

    public void Cuneus()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Cuneus;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Cuneus;
        Agent.speed = 10f;
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "barbarian_sword")
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "arrow")
        {
            Destroy(gameObject);

        }
    }




}
