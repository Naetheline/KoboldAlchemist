using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public GameObject tooltip;
    public TextMeshProUGUI tooltipText;

    private VialVontrol vial;
    private void Start()
    {
        vial = GameObject.Find("vial").GetComponent<VialVontrol>();
    }


    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit.collider == null)
            {
                return;
            }
            Bowl bowl = hit.collider.GetComponent<Bowl>();
            VialVontrol vialToprint = hit.collider.GetComponent<VialVontrol>();
            ResultManager result = hit.collider.GetComponent<ResultManager>();
            if (touch.phase == TouchPhase.Ended)
            {
                
                    if (vial.isEmpty() && bowl != null)
                    {
                        vial.setCurrentIngredient(bowl.getIngredient());
                    }

                    tooltip.SetActive(false);

            }
            else if (touch.phase == TouchPhase.Stationary)
            {      
                if(bowl != null)
                {
                        tooltipText.text = bowl.printIngredient();
                }
                else if (vialToprint != null)
                {
                    tooltipText.text = vialToprint.printIngredient();
                }
                    tooltip.SetActive(true);
            }
            else if (touch.phase == TouchPhase.Began)
            {
                if (result != null)
                {
                    if (vial.isEmpty())
                    {
                        result.HideResult();
                    }
                    else
                    {
                        result.CheckPotion(vial.getCurrentIngredient());
                        vial.clearIngredient();
                    }
                }
            }
            
        }
    }
}
