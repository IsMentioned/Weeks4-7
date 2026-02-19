using Unity.VisualScripting;
using UnityEngine;

public class UI: MonoBehaviour
{
    public Pizza pizza;
    public Topping pizzaScale;
    Vector3 scale = new Vector3(1, 1, 1);
    float sizeCoE;
    public bool previewActive = true;

    public SpriteRenderer money1;
    public SpriteRenderer money2;
    public SpriteRenderer money3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button()
    {
        //Closes the preview menu when the 'Confirm Size' button is pressed.
        gameObject.SetActive(false);
        previewActive = false;


        //Sets the opacity of the dollar sign sprites to 0 when the 'Confirm Size' button is pressed.
        Color money = money1.color;
        money.a = 0f;
        money1.color = money;
        money2.color = money;
        money3.color = money;

    }

    public void Slider(float input)
    {
        //The moving the slider adjusts the size of the pizza sprite (with an adjustment of 1.5 * the scale).
        sizeCoE = input + 1.5f;
        scale = new Vector3(sizeCoE,sizeCoE,1);
        pizzaScale.transform.localScale = scale;

    }

    public void Sell()
    {
        //If the sell button is pressed when the pizza is complete (out of the oven),
        //All major variables will reset and the dollar signs will appear.
        if (pizza.ovenComplete)
        {
            gameObject.SetActive(true);
            pizza.ovenActive = false;
            pizza.location = pizza.spawnPos;
            pizza.ovenComplete = false;
            previewActive = true;
            pizza.textureChange = false;

            Color money = money1.color;
            money.a = 1f;
            money1.color = money;
            money2.color = money;
            money3.color = money;




        }






    }
}

