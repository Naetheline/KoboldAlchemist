using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticVolatileGrog : Bowl
{

    private void Start()
    {
       this.content = new Ingredient(-5, 0, 0, 0, 0, 0, 0, 8, Color.black, "Caustic volatile grog !");
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
        if(content == null)
        {
            return "";
        }
        return content.Name;
    }
}