﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseSmellingNectar : Bowl
{

    private void Start()
    {
        this.content = new Ingredient(0, 0, 0, 0, 0, 8, 0, -3, new Color(0.3f, 0.1f, 0), "Corpse smelling nectar");
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