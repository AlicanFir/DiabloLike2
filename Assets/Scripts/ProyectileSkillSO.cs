using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ProyectileSkillSO", menuName = "Scriptable Objects/ FireBall", order = 0)]
    public class ProyectileSkillSO : SkillSO
    {
        public GameObject proyectilePrefab;

        
        protected override void ExecuteSkill(GameObject caster, Vector3 cursorPoint)
        {
            Instantiate(proyectilePrefab, caster.transform.position + Vector3.up * 1f, caster.transform.rotation); //sale el proyectil
        }
    }
}