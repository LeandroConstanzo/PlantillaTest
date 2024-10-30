using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Referencia al jugador
    public Transform player;

    // Velocidad de movimiento del enemigo
    public float moveSpeed = 3.5f;

    // Distancia m�nima a la que el enemigo puede seguir al jugador
    public float stopDistance = 2.0f;

    // Agente de navegaci�n (NavMeshAgent)
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        // Obtener el componente NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Configurar la velocidad del agente
        navMeshAgent.speed = moveSpeed;

        // Configurar la distancia m�nima para detenerse
        navMeshAgent.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        if (player != null)
        {
            // Establecer el destino del agente hacia la posici�n del jugador
            navMeshAgent.SetDestination(player.position);
        }
    }
}
