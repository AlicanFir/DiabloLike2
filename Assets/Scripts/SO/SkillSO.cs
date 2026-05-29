using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/DialogueSO")]
    public abstract class SkillSO : ScriptableObject
    {
        public float cooldown = 1f;
        public float manaCost = 0f;

        public float timeStamp;

        public event Action OnExecute; //delarar el evento ,,, esto es lo del fading

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
        
        public void TryCastSkill(GameObject caster, Vector3 cursorPoint) // ofensiva a distancia
        {
            if (!IsReady()) return;
            
            //Timestamp marca el emomento al partir del cual puedo volver a utilizar la skill
            timeStamp = Time.time + cooldown;
            OnExecute?.Invoke(); //? pregunta si hay alguien escuchando
            ExecuteSkill(caster, cursorPoint);
        }

        public void TryCastSkill(GameObject caster) // propia a corta distancia
        {
            if (!IsReady()) return;
            OnExecute?.Invoke();
            ExecuteSkill(caster);
        }

        protected abstract void ExecuteSkill(GameObject caster, Vector3 cursorPoint); //cuando aun no sepas que hay lo haces abstracto
        protected abstract void ExecuteSkill(GameObject caster);

    }
}