using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialVontrol : MonoBehaviour
{
    public const float ROTATION_THRESHOLD = 120f;
    private Ingredient currentIngredient;
    private SpriteRenderer vialSprite;

    private void Start()
    {
        vialSprite = GetComponentInChildren<SpriteRenderer>();
        currentIngredient = null;
    }

    public void setCurrentIngredient(Ingredient ingredient)
    {
        if (ingredient != null)
        {
            currentIngredient = ingredient;
            vialSprite.color = ingredient.GetColour();
        }
    }

    public void clearIngredient()
    {
        currentIngredient = null;
        vialSprite.color = Color.white;
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
        
        if(transform.eulerAngles.z >= ROTATION_THRESHOLD || transform.eulerAngles.z <= -ROTATION_THRESHOLD)
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

    // DEBUG

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + Vector3.down, Vector3.down * 10 + transform.position);
    }
}
