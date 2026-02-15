using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.WSA;


//● If the mouse is dragged within the bounds of the pizza and a topping is not currently
//selected.
//○ The pizza moves to the position of the mouse.
//● If pizza enters the oven cycle:
//○ The pizza will lerp into the oven over a period of 1 second.
//○ Then, the pizza will gradually move from left to right across the position of the
//oven over a period of 15 seconds using a lerp.
//○ Then, a ding sound will play and the sell button will be enabled.
//● If the pizza is reset:
//○ The toppings are destroyed.
//○ The size is set to 2 (reset).
//○ The position is reset to the left side

public class Pizza : MonoBehaviour
{
    //bool toppingSelected = false;
    public Vector3 location;
    public Camera main;
    public SpriteRenderer oven;
    public bool ovenActive = false;
    float ovenTimer = 0;
    public Vector3 spawnPos;

    Vector3 startPos = new Vector3(-1.8f, -1.8f, 0);
    Vector3 endPos = new Vector3(6.85f, -1.8f, 0);

    Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos = new Vector3(-5.4f, -1.8f, 0);
        location = spawnPos;
        transform.position = location;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer pizzaRend = GetComponent<SpriteRenderer>();
        mousePos = main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //If the mouse is currently pressed on the pizza, pick it up (maintains mouse position).
        if (Mouse.current.leftButton.isPressed && pizzaRend.bounds.Contains(mousePos) &&  !ovenActive)
        {
            Debug.Log("active");
            location = mousePos;
        }

        //If the pizza is on top of the oven rack and the mouse is released, the pizza enters the oven phase.
        if (oven.bounds.Contains(location) && Mouse.current.leftButton.wasReleasedThisFrame && !ovenActive)
        {
            location = new Vector3(1.5f, 1.5f, 0);
            ovenActive = true;
        }

        if(ovenActive)
        {
            ovenTimer += 1 * Time.deltaTime;
            location = Vector2.Lerp(startPos, endPos, ovenTimer/3);
        }

        transform.position = location;

    }
    public void ConfirmSize()
    {

    }
}
