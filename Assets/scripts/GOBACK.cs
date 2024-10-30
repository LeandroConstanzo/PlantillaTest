using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOBACK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.R))

            SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))

            SceneManager.LoadScene(0);
        {
            if (Input.GetKeyDown(KeyCode.R))

                SceneManager.LoadScene(1);
        }

    }
}
