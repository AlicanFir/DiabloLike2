using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "HealSkillSO", menuName = "Scriptable Objects/HealSkillSO")]
    public class HealSkillSO : SkillSO
    {
        public float healValor;

        public event Action heal;
        
        protected override void ExecuteSkill(GameObject caster, Vector3 cursorPoint) // no lo necesitamos
        {
        }

        protected override void ExecuteSkill(GameObject caster)
        {
            //implementa el evento de curacion que esta escuchando el player
            heal?.Invoke();
        }
    }
}