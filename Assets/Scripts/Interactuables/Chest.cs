using System.Collections;
using UnityEngine;

public class Chest : Interactuable
{

    [SerializeField] private Color interactionColor;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private bool isCorrect = false;
    private Animator anim;
    private AudioSource audio;
    
    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        winScreen.SetActive(false);
        outline.OutlineColor = interactionColor; 
    }
    
    

    public override void Interact(GameObject interactor)
    {
        anim.SetBool("Open", true);
        audio.Play();
        if (isCorrect)
        {
            StartCoroutine(Wait());
        }
        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
