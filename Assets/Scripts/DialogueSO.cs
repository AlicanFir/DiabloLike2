using System.Net.Mime;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    [TextArea(3, 8)] public string[] frases; // el text area es para que se vea bonito en el inspector
    public float tiempoEntreLetras = 8;
    public Color colorDialogo;
    public Sprite faceSprite;
}
