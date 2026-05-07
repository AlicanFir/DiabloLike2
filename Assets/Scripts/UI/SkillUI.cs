using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Image fadingCooldown;

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
        float remaining = 0f;
        while (remaining < skill.cooldown)
        {
            remaining = skill.GetRemainingCooldown();
            fadingCooldown.fillAmount = remaining / skill.cooldown;
            yield return null; //vuelve al siguiente frame, es como un update y cuando el while termina el "update" muere.
        }
        fadingCooldown.fillAmount = 1f;
    }
    
}
