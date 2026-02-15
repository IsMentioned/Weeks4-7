using Unity.VisualScripting;
using UnityEngine;

public class UI: MonoBehaviour
{
    public Pizza pizza;
    Vector3 scale = new Vector3(1, 1, 1);
    float sizeCoE;


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
        gameObject.SetActive(false);
    }

    public void Slider(float input)
    {
        sizeCoE = input + 1.5f;
        scale = new Vector3(sizeCoE,sizeCoE,1);
        pizza.transform.localScale = scale;
    }

    public void Sell()
    {
        Debug.Log("Do it!");
        gameObject.SetActive(true);
        pizza.ovenActive = false;
        pizza.location = pizza.spawnPos;
        

    }
}

