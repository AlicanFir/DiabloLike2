using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public Transform transform { get; }
        void TakeDamage(float damage);
    }
}