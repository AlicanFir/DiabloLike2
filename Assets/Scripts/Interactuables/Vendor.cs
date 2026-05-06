using System.Runtime.Serialization.Formatters.Binary;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Vendor : Interactuable
{
    
    [SerializeField] private Color interactionColor;
    
    [SerializeField] private DialogueSO initialDialogue;
    [SerializeField] private DialogueSO finalDialogue;
    
    [SerializeField] private float animTime;

    [SerializeField] private GameObject shopCanvas;

    private bool shopOpen = false;
    public bool isTalking = false; //TODO ENCAPSULAR

    protected override void Awake()
    {
        base.Awake();
        outline.OutlineColor = interactionColor;
    }
    
    //quiero que mire a que le este interactuando

    public override void Interact(GameObject interactor)
    {
        DialogueSystem.Instance.IniciarDialogo(initialDialogue, this.gameObject);
        
        //ESPERO A QUE ME LLEGUE EL EVENTO DE ABRIR LA TIENDA, QUE ME LO DA EL DIALOGUE SYSTEM AL TERMINAR DE HABLAR
        OpenShop(interactor);
    }
    
    private void OpenShop(GameObject interactor)
    {
        shopCanvas.SetActive(true);
        
    }

    private void CloseShop()
    {
        DialogueSystem.Instance.IniciarDialogo(finalDialogue, null); // para este me interesa que funcione como un npc normal
    }
    
}