using System;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerAttackSystem : MonoBehaviour
    {
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRadius;
        [SerializeField] private LayerMask whatIsDestructable;
        
        [SerializeField] private float damageDealt;
        
        private IDamageable currentDamageable;
        private AudioSource audio;
        
        private Animator anim;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            audio = GetComponent<AudioSource>();
        }

        public void SetTarget(IDamageable damageable)
        {
            currentDamageable = damageable;
            transform.DOLookAt(damageable.transform.position, 0f, AxisConstraint.Y);
            anim.SetBool("Attacking", true);
            //DoDamage();
            
            Debug.Log(currentDamageable.transform.name);
        }

        public void DoDamage()
        {
            audio.Play();
            currentDamageable.TakeDamage(damageDealt);
        }

        public void ClearTarget()
        {
            currentDamageable = null;
            anim.SetBool("Attacking", false);
            
        }

        private void Update()
        {
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(attackPoint.position, attackRadius);
        }
    }
}