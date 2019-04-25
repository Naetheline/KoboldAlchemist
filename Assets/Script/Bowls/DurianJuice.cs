using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianJuice : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, 0, -3, 4, 0, 0,new Color(0.5f, 0.1f, 0.1f), "Durian juice");
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