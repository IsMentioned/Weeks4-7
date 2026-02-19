using Unity.VisualScripting;
using UnityEngine;

public class UI: MonoBehaviour
{
    public Pizza pizza;
    public Topping pizzaScale;
    Vector3 scale = new Vector3(1, 1, 1);
    float sizeCoE;
    public bool previewActive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pizzaScale.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button()
    {
        gameObject.SetActive(false);
        previewActive = false;

    }

    public void Slider(float input)
    {
        sizeCoE = input + 1.5f;
        scale = new Vector3(sizeCoE,sizeCoE,1);
        pizzaScale.transform.localScale = scale;

    }

    public void Sell()
    {
        if (pizza.ovenComplete)
        {
            gameObject.SetActive(true);
            pizza.ovenActive = false;
            pizza.location = pizza.spawnPos;
            pizza.ovenComplete = false;
            previewActive = true;
            pizza.textureChange = false;

            

        }
        

        

    }
}

