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
    public Pizza pizza;


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


//Logic for topping box selection:

        //Pepperoni box
        //If a mouse clicks is on the box, pepperoni will be selected and other toppings will be unselected if pepperoni is currently not selected.
        //If a mouse click is on the box, pepporoni will be unselected if it is currently selected.
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

        //Beef box
        //If a mouse clicks is on the box, beef will be selected and other toppings will be unselected if beef is currently not selected.
        //If a mouse click is on the box, beef will be unselected if it is currently selected.
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

        //Onion box
        //If a mouse clicks is on the box, onion will be selected and other toppings will be unselected if onion is currently not selected.
        //If a mouse click is on the box, onion will be unselected if it is currently selected.
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

//Logic for color of box based on selection.
        //If pepperoni is currently selected, the box will be green.
        //Otherwise, it is white.
        if (peppSelected)
        {
            peppBox.color = Color.green;
        }
        else
        {
            peppBox.color = new Color(255, 255, 255, 255);
        }

        //If beef is currently selected, the box will be green.
        //Otherwise, it is white.
        if (beefSelected)
        {
            beefBox.color = Color.green;
        }
        else
        {
            beefBox.color = new Color(255, 255, 255, 255);
        }

        //If onion is currently selected, the box will be green.
        //Otherwise, it is white.
        if (onionSelected)
        {
            onionBox.color = Color.green;
        }
        else
        {
            onionBox.color = new Color(255, 255, 255, 255);
        }

//Logic for spawning toppings on the pizza sprite.
        //If pepperoni is currently selected and the mouse is clicked on the pizza, pepperoni is instantiated and added to the 'toppings' list.
        if (peppSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(peppPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }

        //If beef is currently selected and the mouse is clicked on the pizza, beef is instantiated and added to the 'toppings' list.
        if (beefSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(beefPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }

        //If onion is currently selected and the mouse is clicked on the pizza, onion is instantiated and added to the 'toppings' list.
        if (onionSelected && pizzaRend.bounds.Contains(mousePos) && Mouse.current.leftButton.wasReleasedThisFrame && !uI.previewActive)
        {
            topping = Instantiate(onionPrefab, mousePos, Quaternion.identity, PizzaBase.transform);
            toppings.Add(topping);
        }


        //If pepperoni, beef, or onion is currently selected, a topping is selected.
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
        //If the 'Sell' button is pressed and the oven cycle is complete, all toppings will be destroyed.
    {
        if (pizza.ovenComplete2)
        {
            for (int i = toppings.Count - 1; i >= 0; i--)
            {
                Destroy(toppings[i]);
                pizza.ovenComplete2 = false;
            }
        }
           

    }
}
