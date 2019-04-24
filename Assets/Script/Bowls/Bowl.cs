using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
 

public class Bowl : MonoBehaviour
{
    [SerializeField]
    protected Ingredient content;

    public virtual void SetContent(Ingredient ingredient)
    {
        content = ingredient;
    }

    public virtual Ingredient getIngredient()
    {
        return content;
    }

    public virtual string printIngredient()
    {
        if(content == null)
        {
            return "Empty";
        }
        return content.Name;
    }

    public bool isEmpty()
    {
        return (content == null);
    }

    public virtual void Process( Ingredient toMix = null)
    {

    }
}
