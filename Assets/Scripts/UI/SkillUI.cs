using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image fading;
    [SerializeField] private SkillSO skill;

    private void OnEnable()
    {
        skill.OnExecute += RefreshFading;
    }

    private void OnDisable()
    {
        skill.OnExecute += RefreshFading;
    }

    private void RefreshFading()
    {
        StartCoroutine(RefreshUI());
    }

    private IEnumerator RefreshUI()
    {
        /*Debug.Log(skill.cooldown);
        float remaining = 0f;
        while (remaining < skill.cooldown)
        {
            remaining = skill.GetRemainingCooldown();
            fading.fillAmount = remaining / skill.cooldown;
            Debug.Log(remaining / skill.cooldown);
            yield return null; //vuelve al siguiente frame, es como un update y cuando el while termina el "update" muere.
        }
        fading.fillAmount = 0f;
        */
        //El codigo de arriba seguía sin funcionarme.
            
        float timer = 0;
        while (timer < skill.cooldown)
        {
            timer += 0.01f;
            fading.fillAmount = timer / skill.cooldown;
            yield return null;
        }
        fading.fillAmount = 0f;
    }
    
}
