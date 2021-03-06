using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Legionary : agent
{

    [SerializeField] public Centurion centurion;
    [SerializeField] private float rank_close_order;
    [SerializeField] private float column_close_order;

    [SerializeField] private float rank_open_order;
    [SerializeField] private float column_open_order;

    [SerializeField] private float rank_testudo;
    [SerializeField] private float column_testudo;

    [SerializeField] private float rank_orbis;
    [SerializeField] private float column_orbis;

    [SerializeField] private float rank_cuneus;
    [SerializeField] private float column_cuneus;

    public Vector3 pos;

    public float distanceOpenOrder = 10f;
    public float distanceCloseOrder;
    public float distanceTestudo;
    public float distanceOrbis;
    public float distanceCuneus;


    public float rotationOrbis;
    public int groupOrbis;

    public int groupCuneus;



    [SerializeField] private Animator animator;
    private bool testudo_stance;

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


    private Formation formation;





    void Start()
    {
        formation = Formation.Open_Order;
        animator.SetBool("testudo_stance", false);
        agent = GetComponent<NavMeshAgent>();



        testudo_stance = false;

        
       
    }


    void Update()
    {
        if (formation == Formation.Open_Order)
            Open_Order();
        if (formation == Formation.Close_Order)
            Close_Order();
        if (formation == Formation.Testudo)
            Testudo();
        if (formation == Formation.Orbis)
            Orbis();
        if (formation == Formation.Cuneus)
            Cuneus();
             
            
            
        

    }

    public void Open_Order()
    {
        testudo_stance = false;
        animator.SetBool("testudo_stance", false);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pos = hit.point;
                pos.x = pos.x + column_close_order * distanceOpenOrder;
                pos.z = pos.z + rank_close_order * -distanceOpenOrder;
                agent.destination = pos;
            }

        }
    }
    public void Close_Order()
    {
        testudo_stance = false;
        animator.SetBool("testudo_stance", false);
        pos = centurion.transform.position;
        pos.x = pos.x + column_close_order * distanceOpenOrder;
        pos.z = pos.z + rank_close_order * -distanceOpenOrder;
        agent.destination = pos;
    }
    public void Testudo()
    {
        testudo_stance = true;
        animator.SetBool("testudo_stance", true);
        pos = centurion.transform.position;
        pos.x = pos.x + column_close_order * distanceOpenOrder;
        pos.z = pos.z + rank_close_order * -distanceOpenOrder;
        agent.destination = pos;
    }
    public void Orbis()
    {
        testudo_stance = false;
        animator.SetBool("testudo_stance", false);
        pos = centurion.transform.position;
        pos.x = pos.x + column_close_order * distanceOpenOrder;
        pos.z = pos.z + rank_close_order * -distanceOpenOrder;
        agent.destination = pos;
    }

    public void Cuneus()
    {
        testudo_stance = false;
        animator.SetBool("testudo_stance", false);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pos = hit.point;
                pos.x = pos.x + column_close_order * distanceOpenOrder;
                pos.z = pos.z + rank_close_order * -distanceOpenOrder;
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
