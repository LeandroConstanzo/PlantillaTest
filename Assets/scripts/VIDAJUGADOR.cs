using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    // Vida máxima del jugador
    public int maxHealth = 100;

    // Vida actual del jugador
    private int currentHealth;

    private void Start()
    {
        // Al iniciar el juego, la salud del jugador es la máxima
        currentHealth = maxHealth;
    }

    // Método que reduce la salud del jugador
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Verifica si la salud del jugador ha llegado a cero o menos
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método que se llama cuando el jugador muere
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(2);

        // Aquí puedes agregar la lógica de muerte, como desactivar el jugador, jugar una animación, etc.
        // Por ejemplo:
        // Destroy(gameObject); // Destruye el objeto del jugador
    }
}