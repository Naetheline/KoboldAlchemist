using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndYellowLiquid : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, -3, 0, 5, 0, 0,  Color.yellow, "Some undefined yellow liquid...");
    }

    public override void SetContent(Ingredient ingredient)
    {
        Debug.Log("Already full");
    }

    public override Ingredient getIngredient()
    {
        return new Ingredient(this.content);
    }

    public override string printIngredient()
    {
        if (content == null)
        {
            return "";
        }
        return content.Name;
    }

}