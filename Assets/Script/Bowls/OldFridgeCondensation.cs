using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldFridgeCondensation : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(-3, 0, 0, 0, 5,  0, Color.cyan, "Old fridge condensation");
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