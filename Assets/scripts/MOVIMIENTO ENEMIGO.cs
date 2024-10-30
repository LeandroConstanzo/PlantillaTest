using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Referencia al jugador
    public Transform player;

    // Velocidad de movimiento del enemigo
    public float moveSpeed = 3.5f;

    // Distancia mínima a la que el enemigo puede seguir al jugador
    public float stopDistance = 2.0f;

    // Agente de navegación (NavMeshAgent)
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        // Obtener el componente NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Configurar la velocidad del agente
        navMeshAgent.speed = moveSpeed;

        // Configurar la distancia mínima para detenerse
        navMeshAgent.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        if (player != null)
        {
            // Establecer el destino del agente hacia la posición del jugador
            navMeshAgent.SetDestination(player.position);
        }
    }
}
