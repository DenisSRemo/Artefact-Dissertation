using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbarian : MonoBehaviour
{

    [SerializeField] private Transform target;

    public float speed;





    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
