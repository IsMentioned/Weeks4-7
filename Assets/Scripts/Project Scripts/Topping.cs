using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Topping : MonoBehaviour
{
    public GameObject peppPrefab;
    public GameObject beefPrefab;
    public GameObject onionPrefab;
    public GameObject topping;
    public GameObject PizzaBase;

    public SpriteRenderer peppBox;
    public SpriteRenderer beefBox;
    public SpriteRenderer onionBox;

    bool peppSelected = false;
    bool beefSelected = false;
    bool onionSelected = false;
    public bool toppingSelected = false;

    Vector3 mousePos;
    public Camera main;
    public UI uI;

    public List<GameObject> toppings;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer pizzaRend = GetComponent<SpriteRenderer>();

        mousePos = main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //if the pepporini box is clicked...
        if (peppBox.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            if (peppSelected == true)
            {
                peppSelected = false;
            }
            else
            {
                peppSelected = true;
                beefSelected = false;
                onionSelected = false;
            }
        }

        if (beefBox.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            if (beefSelected == true)
            {
                beefSelected = false;
            }
            else
            {
                peppSelected = false;
                beefSelected = true;
                onionSelected = false;

            }
        }

        if (onionBox.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            if (onionSelected == true)
            {
                onionSelected = false;

            }
            else
            {
                peppSelected = false;
                beefSelected = false;
                onionSelected = true;
            }
        }

        if (peppSelected)
        {
            peppBox.color = Color.green;
        }
        else
        {
            peppBox.color = new Color(135, 135, 135, 255);
        }


        if (beefSelected)
        {
            beefBox.color = Color.green;
        }
        else
        {
            beefBox.color = new Color(135, 135, 135, 255);
        }


        if (onionSelected)
        {
            onionBox.color = Color.green;
        }
        else
        {
            onionBox.color = new Color(135, 135, 135, 255);
        }



        if (peppSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(peppPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }


        if (beefSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(beefPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }


        if (onionSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(onionPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }


        //true if a topping is currently selected, false otherwise.
        if(peppSelected || beefSelected || onionSelected)
        {
            toppingSelected = true;
        }
        else
        {
            toppingSelected = false;
        }


    }
    public void Sell()
    {
        for (int i = toppings.Count - 1; i >= 0; i--)
        {
            Destroy(toppings[i]);
        }

    }
}
