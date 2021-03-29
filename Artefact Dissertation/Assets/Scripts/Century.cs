using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Century : MonoBehaviour
{



    [SerializeField] private Centurion centurion;
    [SerializeField] private List<Legionary> legionaries; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<legionaries.Count;i++)
        {
            
            legionaries[i].Close_Order();
        }
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
    }

    public void Close_Order()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Close_Order;
            legionaries[i].forming = true;
        }
        centurion.formation = agent.Formation.Close_Order ;
    }

    public void Testudo()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Testudo;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Testudo;
    }


    public void Orbis()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Orbis;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Orbis;
    }

    public void Cuneus()
    {
        for (int i = 0; i < legionaries.Count; i++)
        {

            legionaries[i].formation = agent.Formation.Cuneus;
            legionaries[i].forming = true;
        }

        centurion.formation = agent.Formation.Cuneus;
    }

}
