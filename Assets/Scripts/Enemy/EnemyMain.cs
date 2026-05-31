using System;
using System.Collections;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyMain : Interactuable, IDamageable
    {
        [SerializeField] private float enemyHealth;
        [SerializeField] private float secondsToDie;
        [SerializeField] private float damageDealt = 5;
        
        [SerializeField] private Transform damagePoint;
        [SerializeField] private float  damageRadius;
        [SerializeField] private LayerMask isDamageable;

        private Animator anim;
        private Behaviour agent;
        private bool drawGizmos = true;
        private AudioSource audio;

        private void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<Behaviour>();
            audio = GetComponent<AudioSource>();
        }

        public override void Interact(GameObject interactor)
        {
            Debug.Log(interactor.name + " me hace daño");
        }

        public void TakeDamage(float damage)
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                //animacion de morir
                anim.SetBool("Death", true);
                agent.enabled = false;
                StartCoroutine(KillEnemy());
            }
        }

        IEnumerator KillEnemy()
        {
            yield return new WaitForSeconds(secondsToDie);
            drawGizmos = false;
            this.gameObject.SetActive(false);
            //si lo destruyo da problemas
            //Destroy(this.gameObject);
        }
        
        public void DoDamage(float damageDealt)
        {
            //overlap sphere veo si pillo al player y si si take damage
            Collider[] colliders = Physics.OverlapSphere(damagePoint.position, damageRadius, isDamageable);
            //if (colliders[0] == null) return; // si no impacta con nada
            foreach (Collider hit in colliders)
            {
                hit.GetComponent<PlayerHealthSystem>().TakeDamage(damageDealt);
                audio.Play();
            }
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            Gizmos.DrawSphere(damagePoint.position, damageRadius);
        }
    }
}