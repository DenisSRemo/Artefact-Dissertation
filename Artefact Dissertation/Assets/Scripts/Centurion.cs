using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centurion : agent
{
    
    public Formation formation;
   // [SerializeField] private Animator animator;
    private bool testudo_stance;
    public float angle;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        formation = Formation.Close_Order;
        testudo_stance = false;
        angle = gameObject.transform.eulerAngles.y;
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
    }



    public float GetAngle()
    {
        return angle;
    }
}
