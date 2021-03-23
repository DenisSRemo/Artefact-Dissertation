using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Legionary : agent
{

    [SerializeField] public Centurion centurion;
    [SerializeField] private float offset_y_close_order;
    [SerializeField] private float offset_x_close_order;

    [SerializeField] private float offset_y_open_order;
    [SerializeField] private float offset_x_open_order;

    [SerializeField] private float offset_y_testudo;
    [SerializeField] private float offset_x_testudo;
    [SerializeField] private int rank_testudo;

    [SerializeField] private float offset_y_orbis;
    [SerializeField] private float offset_x_orbis;
    [SerializeField] private float angle_orbis;

    [SerializeField] private float offset_y_cuneus;
    [SerializeField] private float offset_x_cuneus;

    public Vector3 pos;

    public Animator animator;


 



    //[SerializeField] private Animator animator;
    //private bool testudo_stance;

    private float r;
    private Vector3 c1;
    private Vector3 c2;
    private Vector3 c1_exit;
    private Vector3 c2_enter;


    private Vector3 formation_pos;
    private Vector3 formation_dir;
    private Vector3 target_pos;
    private Vector3 target_dir;
    private Vector3 dirVec;

    NavMeshAgent agent;

    private float angle;

   [SerializeField] private Formation formation;


    Vector3 mouseDelta;


    void Start()
    {
       
        //animator.SetBool("testudo_stance", false);
        agent = GetComponent<NavMeshAgent>();

       // agent.speed = 3;

        // testudo_stance = false;

        formation = Formation.Close_Order;

    }


    void Update()
    {
        if (formation == Formation.Open_Order)
        {
            pos = centurion.transform.position;
            angle = -centurion.angle;

            float x;
            float y;
            x = (pos.x + offset_x_open_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_open_order) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
            y = (pos.x + offset_x_open_order) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_open_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

            pos.x = x;
            pos.z = y;


            agent.destination = pos;
            if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                              centurion.angle,
                                                              transform.localEulerAngles.z);
        }
           // Open_Order();
        if (formation == Formation.Close_Order)
        {
            pos = centurion.transform.position;
            angle = -centurion.angle;
            float x;
            float y;
            x = (pos.x + offset_x_close_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_close_order) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
            y = (pos.x + offset_x_close_order) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_close_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

            pos.x = x;
            pos.z = y;


            agent.destination = pos;
            if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                              centurion.angle,
                                                              transform.localEulerAngles.z);

        }
           // Close_Order();
        if (formation == Formation.Testudo)
        {
            pos = centurion.transform.position;
            angle = -centurion.angle;
            float x;
            float y;
            x = (pos.x + offset_x_testudo) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_testudo) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
            y = (pos.x + offset_x_testudo) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_testudo) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

            pos.x = x;
            pos.z = y;


            agent.destination = pos;
            if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                              centurion.angle,
                                                              transform.localEulerAngles.z);


            if (gameObject.tag == "Tesserarius")
            {
                animator.SetBool("testudo_tesserarius", true);
            }
            else
            if (gameObject.tag == "Optio")
            {
                animator.SetBool("testudo_optio", true);
            }
            else
            if (gameObject.tag == "Aquilifer")
            {
                animator.SetBool("testudo_aquilifer", true);
            }
            else
            if (gameObject.tag == "Trumpeter")
            {
                animator.SetBool("testudo_trumpeter", true);
            }
            else
            if (gameObject.tag == "Legionary")
            {
                if (rank_testudo == 1)
                    animator.SetBool("testudo1", true);
                if (rank_testudo == 2)
                    animator.SetBool("testudo2", true);
                if (rank_testudo == 3)
                    animator.SetBool("testudo3", true);
            }

        }
        else
        {
            animator.SetBool("testudo_tesserarius", false);
            animator.SetBool("testudo_optio", false);
            animator.SetBool("testudo_aquilifer", false);
            animator.SetBool("testudo_trumpeter", false);
            animator.SetBool("testudo1", false);
            animator.SetBool("testudo2", false);
            animator.SetBool("testudo3", false);
        }
        // Testudo();
        if (formation == Formation.Orbis)
        {
            pos = centurion.transform.position;
            angle = -centurion.angle;
            float x;
            float y;
            x = (pos.x + offset_x_orbis) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_orbis) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
            y = (pos.x + offset_x_orbis) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_orbis) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

            pos.x = x;
            pos.z = y;


            agent.destination = pos;
            if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                              centurion.angle+angle_orbis,
                                                              transform.localEulerAngles.z);


           


        }
           // Orbis();
        if (formation == Formation.Cuneus)
        {
            pos = centurion.transform.position;
            angle = -centurion.angle;
            float x;
            float y;
            x = (pos.x + offset_x_cuneus) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_cuneus) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
            y = (pos.x + offset_x_cuneus) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_cuneus) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

            pos.x = x;
            pos.z = y;


            agent.destination = pos;
            if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                              centurion.angle,
                                                              transform.localEulerAngles.z);
        }
           // Cuneus();


        mouseDelta = centurion.transform.position - transform.position;

        if (mouseDelta.sqrMagnitude < 0.1f)
        {
            return;
        }

      


    }

    public void Open_Order()
    {
        // testudo_stance = false;
        //animator.SetBool("testudo_stance", false);
        //agent.speed = 10;
        angle = -centurion.angle;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pos = hit.point;
            
                float x;
                float y;

                x = (pos.x + offset_x_open_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - (pos.z + offset_y_open_order) * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad) + pos.z * Mathf.Sin(angle * Mathf.Deg2Rad) + pos.x;
                y = (pos.x + offset_x_open_order) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_open_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;

                pos.x = x;
                pos.z = y;


                agent.destination = pos;
                if (Vector3.Distance(gameObject.transform.position, agent.destination) <= 5)
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                                  centurion.angle,
                                                                  transform.localEulerAngles.z);
            }

        }
    }
    public void Close_Order()
    {
        // testudo_stance = false;
        // animator.SetBool("testudo_stance", false);
       // agent.speed = 5;
        pos = centurion.transform.position;
        angle = -centurion.angle;
      
        float x;
        float y;

        x= (pos.x + offset_x_close_order) * Mathf.Cos(angle * Mathf.Deg2Rad)- (pos.z + offset_y_close_order) * Mathf.Sin(angle * Mathf.Deg2Rad)-pos.x * Mathf.Cos(centurion.angle * Mathf.Deg2Rad)+pos.z* Mathf.Sin(angle * Mathf.Deg2Rad)+pos.x;
        y = (pos.x + offset_x_close_order) * Mathf.Sin(angle * Mathf.Deg2Rad) + (pos.z + offset_y_close_order) * Mathf.Cos(angle * Mathf.Deg2Rad) - pos.x * Mathf.Sin(angle * Mathf.Deg2Rad) - pos.z * Mathf.Cos(angle * Mathf.Deg2Rad) + pos.z;
       
        pos.x = x;
        pos.z = y;


        agent.destination = pos;
        if(Vector3.Distance(gameObject.transform.position,agent.destination)<=5)
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                      centurion.angle,
                                                      transform.localEulerAngles.z);


    }
    public void Testudo()
    {
      //  testudo_stance = true;
      //  animator.SetBool("testudo_stance", true);
        pos = centurion.transform.position;
        pos.x = pos.x + offset_x_testudo * Mathf.Cos(centurion.angle * Mathf.Deg2Rad);
        pos.z = pos.z + offset_y_testudo  * Mathf.Sin(centurion.angle * Mathf.Deg2Rad);
        agent.destination = pos;

    }
    public void Orbis()
    {
      //  testudo_stance = false;
      //  animator.SetBool("testudo_stance", false);
        pos = centurion.transform.position;
        pos.x = pos.x + offset_x_orbis;
        pos.z = pos.z + offset_y_orbis;
        agent.destination = pos;

        gameObject.transform.Rotate(0, angle_orbis, 0);
    }

    public void Cuneus()
    {
       // testudo_stance = false;
        //animator.SetBool("testudo_stance", false);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pos = hit.point;
                pos.x = pos.x + offset_x_cuneus;
                pos.z = pos.z + offset_y_cuneus ;
                agent.destination = pos;
            }

        }
    }





    public void movement()
    {
        dirVec = target_pos - formation_pos;
        Vector3 formation_perp = new Vector3(formation_dir.x * dirVec.x, formation_dir.y * dirVec.y, formation_dir.z * dirVec.z);

        formation_perp = r / formation_perp.magnitude * formation_perp;
        c1 = formation_pos + formation_perp;

        dirVec = -dirVec;
         formation_perp = new Vector3(target_dir.x * dirVec.x, target_dir.y * dirVec.y, target_dir.z * dirVec.z);

        formation_perp = r / formation_perp.magnitude * formation_perp;
        c2 = target_pos + formation_perp;

    }
}
