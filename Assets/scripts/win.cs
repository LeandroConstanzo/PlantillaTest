using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public string playerTag = "Player";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó es el jugador


        if (collision.gameObject.CompareTag(playerTag))
        {

            SceneManager.LoadScene(3);
        }
    }
}
