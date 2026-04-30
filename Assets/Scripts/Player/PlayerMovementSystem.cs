using System;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator anim;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
        }

        public void SetDestination(Vector3 destino, float distanciaParada)
        {
            agent.stoppingDistance = distanciaParada;
            agent.SetDestination(destino);
        }
        
        public bool ReachedDestination()
        {
            return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance; //APRENDER ESTO
        }
        
        
        private void Update()
        {
            anim.SetFloat("BlendSpeed",agent.velocity.magnitude / agent.speed);
        }
    }
}