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

    private Vendor dialogActivator;
    

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


    public void IniciarDialogo(DialogueSO dialog, GameObject activator) //MIRO QUIEN ME HABLA
    {
        DialogoIniciado?.Invoke(); //evento para quitar inputs a player

        if (activator.gameObject.TryGetComponent<Vendor>(out Vendor vendorScript)) //tiene el script de vendor
        {
            // set istalking a true
            dialogActivator = vendorScript;
            dialogActivator.isTalking = true;
        }
        //TODO IS TALKING A TRUE PARA QUE NO ME ABRA LA TIENDA TODAVIA
        
        dialogoActual = dialog;
        marcoDialogo.SetActive(true);
        StartCoroutine(EscribirFrase());
    }

    private IEnumerator EscribirFrase() //typewriter
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
        else 
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
        
        if (dialogActivator != null) // si es un vendedor
        {
            dialogActivator.isTalking = false;
        }
        
        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        
        dialogoActual = null;
        dialogActivator = null;


    }
    
}
