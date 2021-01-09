using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centurion : agent
{
    
    public Formation formation;

    // Start is called before the first frame update
    void Start()
    {
        formation = Formation.Open_Order;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
