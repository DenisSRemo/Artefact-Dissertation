using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanSoldierScript : MonoBehaviour
{
    public enum Formation
    {
        Open_Order,
        Close_Order,
        Testudo,
        Orbis,
        Cuneus
    };
    [SerializeField] private CenturionScript centurion;
    [SerializeField] private int Rank;
    [SerializeField] private int Column;


    public Formation formation;






    
    void Start()
    {
        formation = Formation.Open_Order;
    }

    
    void Update()
    {
        
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
