using UnityEngine;

public class HealthPotion : Interactuable
{
    [SerializeField] private int heal = 5;
    [SerializeField] private Color interactionColor;
    
    
    protected override void Awake()
    {
        
        base.Awake();
        outline.OutlineColor = interactionColor; 
    }
    
    public override void Interact(GameObject interactor)
    {
        Debug.Log(interactor.name); // bien

        if (interactor.TryGetComponent(out PlayerHealthSystem playerHealth))
        {
            playerHealth.HealPlayer(heal);
        }
        
    }
}
