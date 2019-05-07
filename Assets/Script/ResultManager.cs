using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public const int NUMBER_LEVELS = 10;

    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResult;

    [SerializeField]
    private GameObject condPanel;

    [SerializeField]
    private TextMeshProUGUI textCondition;


    private VictoryCondition currentCondition;

    private VictoryCondition[] conditions;

    private int level;

    private void Start()
    {
        conditions = new VictoryCondition[NUMBER_LEVELS];

        GenerateVictoryConditions();

        level = 0;
        this.currentCondition = conditions[level];
        textCondition.text = currentCondition.ToString();
    }

    public void CheckPotion(Ingredient potion)
    {
        if(potion == null)
        {
            return;
        }

        bool ear = checkBodyPart(currentCondition.Ear, potion.Ear);
        bool horn = checkBodyPart(currentCondition.Horn, potion.Horn);
        bool feet = checkBodyPart(currentCondition.Feet, potion.Feet);

        bool makeSmell = checkAttribut(currentCondition.MakeSmell, potion.MakeSmell);
        bool grow = checkAttribut(currentCondition.Grow, potion.Grow);
        bool alter = checkAttribut(currentCondition.Alter, potion.Alter);
        
        if(ear && horn && feet && makeSmell && grow && alter)
        {
            textResult.text += "It worked, thank you !";

            level++;
            if (level > NUMBER_LEVELS)
            {
                level = 0;
            }

            currentCondition = conditions[level];

            textCondition.text = currentCondition.ToString();
        }
        else
        {
            textResult.text = AttributePotion(potion);
        }
        resultPanel.SetActive(true);
        condPanel.SetActive(false);
        
    }

    public void HideResult()
    {
        resultPanel.SetActive(false);
        condPanel.SetActive(true);
    }

    private bool checkBodyPart(int conditionAttribute, float potionAttribute)
    {
        switch (conditionAttribute)
        {
       
            case -1: return (potionAttribute <= -VictoryCondition.EFFECT);
            case 0: return (potionAttribute > -VictoryCondition.EFFECT);
            case 1: return (potionAttribute >= VictoryCondition.EFFECT); 
            default: return false;
        }
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

        if ( (Mathf.Abs(potion.Ear) < VictoryCondition.EFFECT &&
              Mathf.Abs(potion.Feet) < VictoryCondition.EFFECT &&
              Mathf.Abs(potion.Horn) < VictoryCondition.EFFECT)
            || (Mathf.Abs(potion.MakeSmell) < VictoryCondition.EFFECT &&
                Mathf.Abs(potion.Grow) < VictoryCondition.EFFECT &&
                Mathf.Abs(potion.Alter) < VictoryCondition.EFFECT))
        {
            sb.Append("It did nothing at all !");
        }
        else
        {
            sb.Append("It made my \n");

            sb.Append((potion.Ear >= VictoryCondition.EFFECT) ? "ears " : "");
            sb.Append((potion.Ear <= -VictoryCondition.EFFECT) ? "eyes " : "");
            sb.Append((potion.Horn >= VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT) ? "and horns " : "horns ") : "");
            sb.Append((potion.Horn <= -VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT) ? "and tail " : "tail ") : "");
            sb.Append((potion.Feet >= VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT || potion.Horn >= VictoryCondition.EFFECT || potion.Horn <= -VictoryCondition.EFFECT) ? "and feet " : "feet ") : "");
            sb.Append((potion.Feet <= -VictoryCondition.EFFECT) ? ((potion.Ear >= VictoryCondition.EFFECT || potion.Ear <= -VictoryCondition.EFFECT || potion.Horn >= VictoryCondition.EFFECT || potion.Horn <= -VictoryCondition.EFFECT) ? "and hands " : "hands ") : "");

            sb.Append("\n");

            sb.Append((Mathf.Abs(potion.MakeSmell) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
            sb.Append(((potion.MakeSmell) <= -VictoryCondition.EFFECT) ? "less smelly\n" : ((potion.MakeSmell >= VictoryCondition.EFFECT) ? "more smelly\n" : ""));
            sb.Append((Mathf.Abs(potion.Grow) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
            sb.Append((potion.Grow <= -VictoryCondition.EFFECT) ? "smaller\n" : ((potion.Grow >= VictoryCondition.EFFECT) ? "bigger\n" : ""));
            sb.Append((Mathf.Abs(potion.Alter) >= VictoryCondition.STRONG_EFFECT) ? "a lot " : "");
            sb.Append((potion.Alter <= -VictoryCondition.EFFECT) ? "less colourful." : ((potion.Alter >= VictoryCondition.EFFECT) ? "more colourful." : ""));

        }
        return sb.ToString();
    }


    private void GenerateVictoryConditions()
    {
        conditions[0] = new VictoryCondition(0, 0, 1, 0, -1, 0);
        conditions[1] = new VictoryCondition(1, 0, 0, 0, 2, 0);
        conditions[2] = new VictoryCondition(0, 0, -1, -2, 0, 0);
        conditions[3] = new VictoryCondition(0, 1, 0, 0, 0, -1);
        conditions[4] = new VictoryCondition(-1, 0, 0, 0, 1, 1);
        conditions[5] = new VictoryCondition(0, -1, 0, 1, 0, 0);
        conditions[6] = new VictoryCondition(-1, -1, 1, 0, 0, 2);
        conditions[7] = new VictoryCondition(0, 0, -1, -1, 0, 0);
        conditions[8] = new VictoryCondition(0, 1, 0, 0, 0, -2);
        conditions[9] = new VictoryCondition(0, 0, 1, 0, -2, 0);
    }
}
