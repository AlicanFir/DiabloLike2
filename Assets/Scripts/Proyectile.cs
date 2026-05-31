using System;
using Enemy;
using Unity.Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class Proyectile : MonoBehaviour
    {
        [SerializeField] private float proyectileSpeed;
        [SerializeField] private float proyectileDamage;
        [SerializeField] private float collisionRadius;
        [SerializeField] private LayerMask canCollision;
        
        private void Start()
        {
            GetComponent<Rigidbody>().linearVelocity = proyectileSpeed * transform.forward;
        }
        

        private void Update()
        {
            CheckIfHit();   
            
            float timer = 0f;
            if (timer >= 20)
            {
                Destroy(this.gameObject);
            }
            timer += Time.deltaTime;
        }

        private void CheckIfHit()
        {
            Collider[] collisions = Physics.OverlapSphere(this.gameObject.transform.position, collisionRadius, canCollision);

            foreach (Collider col in collisions)
            {
                if (col == null) return; // si no colisiona con nada
                col.GetComponent<EnemyMain>().TakeDamage(proyectileDamage);
                
                Destroy(this.gameObject);
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(this.gameObject.transform.position, collisionRadius);
        }
    }
}