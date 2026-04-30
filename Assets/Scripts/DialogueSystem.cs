using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; private set; }
    private DialogueSO dialogoActual;

    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text contenedorTexto;

    private int indiceFraseActual = 0;
    private bool escribiendo = false;

    public event Action DialogoIniciado, DialogoTerminado;
    

    private void Awake() // el singleton me arrastra la ui
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        marcoDialogo.SetActive(false);
    }


    public void IniciarDialogo(DialogueSO dialog)
    {
        DialogoIniciado?.Invoke(); //evento para quitar inputs a player
        
        dialogoActual = dialog;
        marcoDialogo.SetActive(true);
        StartCoroutine(EscribirFrase());
    }

    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        contenedorTexto.text = string.Empty;
        string fraseAEscribir = dialogoActual.frases[indiceFraseActual];
        char[] fraseEnLetras = fraseAEscribir.ToCharArray();
        
        foreach (char caracter in fraseEnLetras)
        {
            contenedorTexto.text += caracter;
            yield return new WaitForSeconds(dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        escribiendo = false;
        contenedorTexto.text = dialogoActual.frases[indiceFraseActual]; //pone todo el texto de golpe
    }
    
    public void SiguienteFrase()
    {
        if (escribiendo)
        {
            CompletarFrase();
        }
        else //TODO
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frases.Length) //miro si hay frases disponibles
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
    }

    private void FinalizarDialogo()
    {
        DialogoTerminado.Invoke();
        
        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        dialogoActual = null;
    }
    
}
