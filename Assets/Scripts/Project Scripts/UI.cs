using Unity.VisualScripting;
using UnityEngine;

public class UI: MonoBehaviour
{
    public Pizza pizza;
    Vector3 scale = new Vector3(1, 1, 1);
    float sizeCoE;
    public bool previewActive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pizza.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button()
    {
        Debug.Log("Hello???");
        gameObject.SetActive(false);
        previewActive = false;

    }

    public void Slider(float input)
    {
        sizeCoE = input + 1.5f;
        scale = new Vector3(sizeCoE,sizeCoE,1);
        pizza.transform.localScale = scale;

    }

    public void Sell()
    {
        gameObject.SetActive(true);
        pizza.ovenActive = false;
        pizza.location = pizza.spawnPos;
        previewActive = true;
        

    }
}

