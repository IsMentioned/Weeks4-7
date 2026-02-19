using UnityEngine;
using UnityEngine.UI;

public class OvenSlider : MonoBehaviour
{
    public Slider ovenSlider;

    public Pizza pizza;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       //The value of the oven slider will be equal to the value of the oven timer.
        ovenSlider.value = pizza.ovenTimer;
    }
}