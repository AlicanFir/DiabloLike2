using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMain : MonoBehaviour
    {

        private Camera cam;
        private PlayerInput input;
    
        private Interactuable currentInteractuable; // puede que hagas un click en un cofre y que targetee al cofre
        private Vector3 currentDestination;

        private PlayerMovementSystem movementSystem;
        private PlayerAttackSystem attackSystem;
        
        
        private void Awake()
        {
            cam = Camera.main;
            input = GetComponent<PlayerInput>();

            movementSystem = GetComponent<PlayerMovementSystem>();
            attackSystem = GetComponent<PlayerAttackSystem>();
        }

        private void OnEnable()
        {
            DialogueSystem.Instance.DialogoIniciado += CambiarActionMapping;
            DialogueSystem.Instance.DialogoTerminado += CambiarAGameplayInputMapping;
            input.actions["SiguienteFrase"].started += NotificarCambioDeFrase;
            input.actions["Click"].started += OnMouseClicked;
        }

        private void OnDisable()
        {
            DialogueSystem.Instance.DialogoIniciado -= CambiarActionMapping;
            DialogueSystem.Instance.DialogoTerminado -= CambiarAGameplayInputMapping;
            input.actions["SiguienteFrase"].started -= NotificarCambioDeFrase;
            input.actions["Click"].started -= OnMouseClicked;
        }
    
        #region Todo lo relacionado con inputs
    
        private void CambiarAGameplayInputMapping()
        {
            input.SwitchCurrentActionMap("Gameplay");
        }

        private void NotificarCambioDeFrase(InputAction.CallbackContext obj)
        {
            DialogueSystem.Instance.SiguienteFrase();
        }

        private void CambiarActionMapping()
        {
            input.SwitchCurrentActionMap("Interacting");
        }
    
        #endregion
    
        //se ejecuta cuando se hace click
        private void OnMouseClicked(InputAction.CallbackContext obj)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out RaycastHit hit)) return; //si no pillas nada ps sales
            // a partir de aqui el codigo es si has impactado
            
            float stoppingDistance = 0;
            
            //he clickado un interactuable
            if (hit.transform.TryGetComponent(out Interactuable interactuable))
            {
                currentInteractuable = interactuable; //almaceno la info del interactuable clickado
                stoppingDistance = interactuable.InteractionDistance;
                currentDestination = interactuable.transform.position;
                
            }
            else
            {
                //he clickado suelo
                currentInteractuable = null;
                currentDestination = hit.point;
                attackSystem.ClearTarget();
            }
            
            movementSystem.SetDestination(currentDestination, stoppingDistance);
        }

        private void Update()
        {
            
            if(currentInteractuable != null)
            {
                currentDestination = currentInteractuable.transform.position; //sobreescribes el antiguo destino
                movementSystem.SetDestination(currentDestination, currentInteractuable.InteractionDistance);
            }
            
            if (movementSystem.ReachedDestination())
            {
                if (!currentInteractuable) return;
                
                if (currentInteractuable.TryGetComponent(out IDamageable damageable))
                {
                    attackSystem.SetTarget(damageable);
                }
                else
                {
                    currentInteractuable?.Interact(this.gameObject);
                    currentInteractuable = null;
                    attackSystem.ClearTarget();
                }
            }
            
            
        
            //Hacer un blendTree que se actualice de acuerdo a tu velocidad
            // Velocidad máxima -- agent.speed
            // Valocidad actual -- agent.velocity.magnitude
        }
    }
}
