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
            legionaries[i].centurion = centurion;
            legionaries[i].Open_Order();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
