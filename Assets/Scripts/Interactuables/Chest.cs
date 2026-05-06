using UnityEngine;

public class Chest : Interactuable
{

    [SerializeField] private Color interactionColor;
    protected override void Awake()
    {
        base.Awake();
        outline.OutlineColor = interactionColor; 
    }

    public override void Interact(GameObject interactor)
    {
        Debug.Log("mmmm dinero");
    }
}
