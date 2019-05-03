using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarangTea : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, -5, 0, 0, 0, 3, new Color(0.2f, 0, 0.2f), "Marang tea");
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