using System;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class SkillCasterSystem : MonoBehaviour
    {
        [SerializeField] private SkillSO[] skills;

        private PlayerInput playerInput;
        private Camera cam;
        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            cam = Camera.main;
        }

        private void OnEnable()
        {
            playerInput.actions["Skill1"].started += CastSkill1; 
        }
        private void OnDisable()
        {
            playerInput.actions["Skill1"].started -= CastSkill1; 
        }

        private void CastSkill1(InputAction.CallbackContext obj)
        {
            //1. Interpretar posicion del raton
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (!Physics.Raycast(ray, out RaycastHit hit)) return;

            Vector3 cursorPoint = hit.point;
            //2. Enfocar al jugador para que mire en dicha direccrion
            
            transform.DOLookAt(cursorPoint, 0f, AxisConstraint.Y)
                .OnComplete(() => skills[0].TryCastSkill(gameObject, cursorPoint));

            //3. Ejecura la habilidad

        }

    }
}