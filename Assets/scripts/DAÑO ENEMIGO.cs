using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Daño que el enemigo hace al jugador
    public int damage = 10;

    // Tag que identifica al jugador
    public string playerTag = "Player";

    // Método que se ejecuta cuando el enemigo colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó es el jugador
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Intenta obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Si el jugador tiene el componente PlayerHealth, le aplicamos el daño
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}

