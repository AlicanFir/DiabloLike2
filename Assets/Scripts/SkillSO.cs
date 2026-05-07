using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class SkillSO : ScriptableObject
    {
        public float cooldown = 1f;
        public float manaCost = 0f;

        public float timeStamp;

        public event Action OnExecute;

        private void OnEnable()
        {
            //cada vez que empezamos el juego me aseguro que este Asset se limpie y tome los valores por defecto.
            timeStamp = 0;
        }

        public float GetRemainingCooldown()
        {
            return timeStamp - Time.time;
        }

        private bool IsReady()
        {
            return Time.time >= timeStamp;
        }
        
        public void TryCastSkill(GameObject caster, Vector3 cursorPoint)
        {
            if (!IsReady()) return;
            
            //Timestamp marca el emomento al partir del cual puedo volver a utilizar la skill
            timeStamp = Time.time + cooldown;
            OnExecute?.Invoke(); //? pregunta si hay alguien escuchando
            ExecuteSkill(caster, cursorPoint);
        }

        protected abstract void ExecuteSkill(GameObject caster, Vector3 cursorPoint); //cuando aun no sepas que hay lo haces abstracto

    }
}