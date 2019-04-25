using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResult;

    public void CheckPotion(Ingredient potion)
    {
        if(potion == null)
        {
            return;
        }

        textResult.text = potion.ToString();
        resultPanel.SetActive(true);
    }

    public void HideResult()
    {
        resultPanel.SetActive(false);
    }
}
