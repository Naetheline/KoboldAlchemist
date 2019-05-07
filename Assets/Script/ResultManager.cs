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

        StringBuilder sb = new StringBuilder();

        bool ear = checkAttribut(condition.Ear, potion.Ear);
        bool horn = checkAttribut(condition.Horn, potion.Horn);
        bool feet = checkAttribut(condition.Feet, potion.Feet);

        bool makeSmell = checkAttribut(condition.MakeSmell, potion.MakeSmell);
        bool grow = checkAttribut(condition.Grow, potion.Grow);
        bool alter = checkAttribut(condition.Alter, potion.Alter);

        //textResult.text = sb.ToString() + potion.ToString();
        
        if(ear && horn && feet && makeSmell && grow && alter)
        {
            textResult.text += "It worked, thank you !";

            // TODO 
            // Add some sort of score

            condition = new VictoryCondition();

            textCondition.text = condition.ToString();
        }
        else
        {
            // TODO
            // Find a way to words the results in a correct english sentence...
            sb.Append("Ears : " + ear);
            sb.Append("\nHorns : " + horn);
            sb.Append("\nFeet : " + feet);

            sb.Append("\n\nMake smell : " + makeSmell);
            sb.Append("\nGrow : " + grow);
            sb.Append("\nAlter : " + alter);
            sb.Append("\n\n");

        }


        resultPanel.SetActive(true);

    }

    public void HideResult()
    {
        resultPanel.SetActive(false);
    }

    private bool checkAttribut(int conditionAttribute, float potionAttribute)
    {
        switch (conditionAttribute)
        {
            case -2: return (potionAttribute <= -VictoryCondition.STRONG_EFFECT);
            case -1: return (potionAttribute <= -VictoryCondition.EFFECT && potionAttribute > -VictoryCondition.STRONG_EFFECT) ;
            case 0: return (potionAttribute > -VictoryCondition.EFFECT && potionAttribute < VictoryCondition.EFFECT);
            case 1: return (potionAttribute >= VictoryCondition.EFFECT && potionAttribute < VictoryCondition.STRONG_EFFECT);
            case 2: return (potionAttribute >= VictoryCondition.STRONG_EFFECT);
            default: return false;
        }
    }

    private string AttributePotion(Ingredient potion)
    {
        StringBuilder sb = new StringBuilder();


        sb.Append("It made my \n");

        sb.Append((potion.Ear >= VictoryCondition.EFFECT) ? "ears " : "");
        sb.Append((potion.Ear <= -VictoryCondition.EFFECT) ? "eyes " : "");
        sb.Append((potion.Horn >= VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT) ? "and horns " : "horns ") : "");
        sb.Append((potion.Horn <= -VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT) ? "and tail " : "tail ") : "");
        sb.Append((potion.Feet >= VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT || potion.Horn >= VictoryCondition.EFFECT || potion.Horn <= -VictoryCondition.EFFECT ) ? "and feet " : "feet ") : "");
        sb.Append((potion.Feet <= -VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT || potion.Horn >= VictoryCondition.EFFECT || potion.Horn <= -VictoryCondition.EFFECT) ? "and hands " : "hands ") : "");

        sb.Append("\n");

        sb.Append((Mathf.Abs(potion.MakeSmell) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
        sb.Append( ((potion.MakeSmell) <= -VictoryCondition.EFFECT) ? "less smelly\n" :((potion.MakeSmell >= VictoryCondition.EFFECT)? "more smelly\n" : ""));
        sb.Append((Mathf.Abs(potion.Grow) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
        sb.Append((potion.Grow <= -VictoryCondition.EFFECT) ? "smaller\n" : ((potion.Grow >= VictoryCondition.EFFECT) ? "bigger\n" :""));
        sb.Append((Mathf.Abs(potion.Alter) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
        sb.Append((potion.Alter <= -VictoryCondition.EFFECT) ? "less colourful." : ((potion.Alter >= VictoryCondition.EFFECT) ? "more colourful." :""));

        return sb.ToString();
    }
}
