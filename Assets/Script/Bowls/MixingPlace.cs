using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingPlace : Bowl
{
    public override void Process(Ingredient toMix)
    {
        if (content != null && toMix != null)
        {
            this.content.Mix(toMix);
        }
    }
    public override Ingredient getIngredient()
    {
        if (content == null)
        {
            return null;
        }
        Ingredient toReturn = new Ingredient( this.content);
        this.content = null;
        return toReturn;
    }
}
