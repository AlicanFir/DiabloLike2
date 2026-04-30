using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyMain : Interactuable, IDamageable
    {
        public override void Interact(GameObject interactor)
        {
            Debug.Log(interactor.name + " me hace daño");
        }

        public void TakeDamage(float damage)
        {
            
        }
    }
}