using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianJuice : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, 0, -3, 4, 0, 0, Color.yellow, "Durian juice");
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