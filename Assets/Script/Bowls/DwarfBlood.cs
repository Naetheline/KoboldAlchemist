using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfBlood : Bowl
{
    public void Start()
    {
       content = new Ingredient(0, 8, 0, 0, 7, 0, 0, 0, new Color(0.3f, 0, 0 ), "Dwarf blood");
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
