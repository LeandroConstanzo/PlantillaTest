using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    // Vida m�xima del jugador
    public int maxHealth = 100;

    // Vida actual del jugador
    private int currentHealth;

    private void Start()
    {
        // Al iniciar el juego, la salud del jugador es la m�xima
        currentHealth = maxHealth;
    }

    // M�todo que reduce la salud del jugador
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Verifica si la salud del jugador ha llegado a cero o menos
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo que se llama cuando el jugador muere
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(2);

        // Aqu� puedes agregar la l�gica de muerte, como desactivar el jugador, jugar una animaci�n, etc.
        // Por ejemplo:
        // Destroy(gameObject); // Destruye el objeto del jugador
    }
}