using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Image manabarSprite;
    [SerializeField] private float reduceSpeed = 2;

    private float target = 1;

    public void UpdateManaBar(float maxMana, float currentMana)
    {
        target = currentMana / maxMana;     //reduces the mana bar fill depending on its mana usage
    }

    void Update()
    {
        manabarSprite.fillAmount = Mathf.MoveTowards(manabarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);  //reduces the bar's fill 
    }
}
