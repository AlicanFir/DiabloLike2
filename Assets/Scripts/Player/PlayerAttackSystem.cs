using System;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerAttackSystem : MonoBehaviour
    {
        private IDamageable currentDamageable;
        
        private Animator anim;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        public void SetTarget(IDamageable damageable)
        {
            currentDamageable = damageable;
            transform.DOLookAt(damageable.transform.position, 0f, AxisConstraint.Y);
            anim.SetBool("Attacking", true);

        }

        public void ClearTarget()
        {
            currentDamageable = null;
            anim.SetBool("Attacking", false);
            
        }

        private void Update()
        {
            
        }
    }
}