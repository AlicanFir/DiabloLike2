using System.Runtime.Serialization.Formatters.Binary;
using DG.Tweening;
using UnityEngine;

public class NPC : Interactuable
{
    
    [SerializeField] private Color interactionColor;
    [SerializeField] private DialogueSO npcDialogue;

    protected override void Awake()
    {
        base.Awake();
        outline.OutlineColor = interactionColor;
    }
    
    //quiero que mire a que le este interactuando

    public override void Interact(GameObject interactor)
    {
        transform.DOLookAt(interactor.transform.position, 2f, AxisConstraint.Y).OnComplete(DoInteraction);
        
    }

    private void DoInteraction()
    {
        DialogueSystem.Instance.IniciarDialogo(npcDialogue);
    }
}
