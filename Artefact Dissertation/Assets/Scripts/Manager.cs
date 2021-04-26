using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // activate the scenario
    public void functionForButton(GameObject gameObject)
    {

        gameObject.SetActive(true);
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
