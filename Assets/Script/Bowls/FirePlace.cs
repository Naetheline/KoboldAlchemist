using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : Bowl
{
    public override void Process(Ingredient toMix)
    {
        this.content.Heat();
    }
    public override Ingredient getIngredient()
    {
        if(content == null)
        {
            return null;
        }
        Ingredient toReturn = new Ingredient(this.content);
        this.content = null;
        return toReturn;
    }
}
