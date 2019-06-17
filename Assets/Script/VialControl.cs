using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class VialControl : MonoBehaviour
{
    public const float ROTATION_THRESHOLD_MIN = 120f;
    public const float ROTATION_THRESHOLD_MAX = 240f;
    private Ingredient currentIngredient;
    private SpriteRenderer vialSprite;
    private Light2D glow;

    private void Start()
    {
        vialSprite = GetComponentInChildren<SpriteRenderer>();
        currentIngredient = null;
        glow = GetComponentInChildren<Light2D>();
        if(glow == null)
        {
            Debug.Log("Did not find the glow light");
        }
        else
        {
            glow.color = Color.black;
            glow.intensity = 0;
        }
    }

    public void setCurrentIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            currentIngredient = ingredient;
            vialSprite.color = ingredient.GetColour();
            if(ingredient.IsGlowing())
            {
                glow.color = ingredient.GetColour();
                glow.intensity = ingredient.GlowIntensity();
            }
        }
    }

    public Ingredient getCurrentIngredient()
    {
        return currentIngredient;
    }

    public void clearIngredient()
    {
        currentIngredient = null;
        vialSprite.color = Color.white;
        glow.color = Color.black;
        glow.intensity = 0;
    }
    
    public bool isEmpty()
    {
        return currentIngredient == null;
    }
    public string printIngredient()
    {
        if(isEmpty())
        {
            return "Empty";
        }
        return currentIngredient.Name;
    }

    void LateUpdate()
    {
        Quaternion desiredRotation = transform.rotation;

        DetectTouchMovement.Calculate();

        if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
        { // rotate
            Vector3 rotationDeg = Vector3.zero;
            rotationDeg.z = DetectTouchMovement.turnAngleDelta;
            desiredRotation *= Quaternion.Euler(rotationDeg);
        }
        
        transform.rotation = desiredRotation;
        
        if(transform.eulerAngles.z >= ROTATION_THRESHOLD_MIN && transform.eulerAngles.z <= ROTATION_THRESHOLD_MAX)
        {
             Pour(); 
        }
    }

    private void Pour()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position + Vector3.down, Vector2.down);

        if (hit.collider != null)
        {
            Bowl bowl = hit.collider.GetComponent<Bowl>();
            if (bowl != null && !this.isEmpty() && !(bowl is MixingPlace))
            {
                bowl.SetContent(this.currentIngredient);
                bowl.Process();
            }
            else if (bowl != null && !this.isEmpty() && bowl is MixingPlace)
            {
                if (bowl.isEmpty())
                {
                    bowl.SetContent(this.currentIngredient);
                }
                else
                {
                    bowl.Process(this.currentIngredient);
                }
            }
        }

        this.clearIngredient();
    }
}
