using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobbitLymph : Bowl
{
    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, 7, 0, 0, -7, 0, new Color(0.3f, 0.3f, 0.3f), "Hobbit lymph");
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
