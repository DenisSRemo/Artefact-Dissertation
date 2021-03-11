using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centurion : agent
{
    
    public Formation formation;
   // [SerializeField] private Animator animator;
    private bool testudo_stance;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        formation = Formation.Close_Order;
        testudo_stance = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(formation==Formation.Testudo)
        //{
        //    animator.SetBool("testudo_stance", true);
        //}
        //else
        //    animator.SetBool("testudo_stance", false);
    }
}
