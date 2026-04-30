using System;
using UnityEngine;
using UnityEngine.EventSystems;
    
[RequireComponent(typeof(Outline))]

public abstract class Interactuable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //diferencias entre interfaces y abstractas, permite tanto funciones con cuerpo como sin cuerpo
    //si necesito datos uso una clase abstracta
    //una interfaz es como un canal
    
    [field: SerializeField] public float InteractionDistance { get; private set; }
    
    protected Outline outline; // los hijos pueden acceder a el
    [SerializeField] protected Texture2D interactionIcon;
    [SerializeField] protected Texture2D defaultCursor;
    
    protected virtual void Awake() // se puede editar en el hijo
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        outline.OutlineWidth = 4;
        Cursor.SetCursor(defaultCursor, new Vector2(0.5f, 0.5f), CursorMode.Auto);
    }

    public abstract void Interact(GameObject interactor);
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
        Cursor.SetCursor(interactionIcon, new Vector2(0.5f, 0.5f), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
        Cursor.SetCursor(defaultCursor, new Vector2(0.5f, 0.5f), CursorMode.Auto);
    }
}
