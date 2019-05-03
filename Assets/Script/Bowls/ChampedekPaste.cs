using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampedekPaste : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(-5, 0, 0, -5, 0, 0, new Color(0, 0.1f, 0), "Champedek oil");
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