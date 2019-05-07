using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResult;

    [SerializeField]
    private TextMeshProUGUI textCondition;



    private VictoryCondition condition;

    private void Start()
    {
        this.condition = new VictoryCondition();
        textCondition.text = condition.ToString();
    }

    public void CheckPotion(Ingredient potion)
    {
        if(potion == null)
        {
            return;
        }

        // TODO Wrtie text for the attribute check

        StringBuilder sb = new StringBuilder();

        bool ear = checkAttribut(condition.Ear, potion.Ear);
        bool horn = checkAttribut(condition.Horn, potion.Horn);
        bool feet = checkAttribut(condition.Feet, potion.Feet);

        bool makeSmell = checkAttribut(condition.MakeSmell, potion.MakeSmell);
        bool grow = checkAttribut(condition.Grow, potion.Grow);
        bool alter = checkAttribut(condition.Alter, potion.Alter);

        sb.Append("Ears : " + ear);
        sb.Append("\nHorns : " + horn);
        sb.Append("\nFeet : " + feet);

        sb.Append("\n\nMake smell : " + makeSmell );
        sb.Append("\nGrow : " + grow);
        sb.Append("\nAlter : " + alter );
        sb.Append("\n");


        textResult.text = sb.ToString() + potion.ToString();
        

        if(ear && horn && feet && makeSmell && grow && alter)
        {
            textResult.text += "\n\tVictory !";

            condition = new VictoryCondition();

            textCondition.text = condition.ToString();
        }


        resultPanel.SetActive(true);

    }

    public void HideResult()
    {
        resultPanel.SetActive(false);
    }

    private bool checkAttribut(float potionAttribute, int conditionAttribute)
    {
        switch (conditionAttribute)
        {
            case -2: return potionAttribute <= -VictoryCondition.STRONG_EFFECT;
            case -1: return potionAttribute <= -VictoryCondition.EFFECT && potionAttribute > -VictoryCondition.STRONG_EFFECT ;
            case 0: return potionAttribute > -VictoryCondition.EFFECT && potionAttribute < VictoryCondition.EFFECT;
            case 1: return potionAttribute >= VictoryCondition.EFFECT && potionAttribute < VictoryCondition.STRONG_EFFECT;
            case 2: return potionAttribute >= VictoryCondition.STRONG_EFFECT;
            default: return false;
        }
    }
}
