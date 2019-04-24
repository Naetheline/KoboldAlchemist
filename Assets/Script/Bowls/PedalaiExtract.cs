using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalaiExtract : Bowl
{

    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, -3, 0, 0, -6, 0, new Color(0.1f, 0.1f, 0.1f), "Pedalai extract");
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
