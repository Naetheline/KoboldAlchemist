using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobbitLymph : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, 7, 0, 0, -7, 0, Color.cyan, "Hobbit lymph");
    }

    public override void SetContent(Ingredient ingredient)
    {
        Debug.Log("Already full");
    }

    public override Ingredient getIngredient()
    {
        return this.content;
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
