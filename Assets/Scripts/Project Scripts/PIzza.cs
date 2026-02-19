using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class Pizza : MonoBehaviour
{
    //bool toppingSelected = false;
    public Vector3 location;
    public Camera main;
    public SpriteRenderer oven;
    public SpriteRenderer pizzaRend;
    public bool ovenActive = false;
    public bool ovenComplete = false;
    public bool ovenComplete2 = false;
    public float ovenTimer = 0;
    public Vector3 spawnPos;
    public SpriteRenderer pizzaCheese;

    public bool textureChange = false;

    Vector3 startPos = new Vector3(-1.8f, -1.8f, 0);
    Vector3 endPos = new Vector3(6.85f, -1.8f, 0);

    public Vector3 mousePos;

    public Topping topping;
    public UI uI;

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
        mousePos = main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //If the mouse is currently pressed on the pizz, pick it up (maintains mouse position).
        //Only allowed if a topping is not currently selected, and the oven is not currently active.
        if (Mouse.current.leftButton.isPressed && pizzaRend.bounds.Contains(mousePos) &&  !ovenActive && !topping.toppingSelected && !uI.previewActive)
        {
            location = mousePos;
        }

        //If the pizza is on top of the oven rack and the mouse is released, the pizza enters the oven phase.
        if (oven.bounds.Contains(location) && Mouse.current.leftButton.wasReleasedThisFrame && !ovenActive)
        {
            location = new Vector3(1.5f, 1.5f, 0);
            ovenActive = true;
        }

        //If the oven is currently active, a timer runs, and the pizza lerps according to the value of the timer.
        if(ovenActive)
        {
            ovenTimer += 1 * Time.deltaTime;
            location = Vector2.Lerp(startPos, endPos, ovenTimer/10);
        }

        //If the oven has been active for more than 5 seconds, the texutre of the pizza changes.
        if(ovenTimer > 5)
        {
            textureChange = true;

        }

        //If the texture is called to change, the opacity of the 'Cooked Pizza' sprite is increased to max.
        if (textureChange)
        {
            Color cheese = pizzaCheese.color;
            cheese.a = 1f;
            pizzaCheese.color = cheese;
        }

        //Otherwise, the opacity of the 'Cooked Pizza' sprite is set to 0.
        else
        {
            Color cheese = pizzaCheese.color;
            cheese.a = 0f;
            pizzaCheese.color = cheese;

        }
        //The ovenTimer stops after 10 seconds, and signals completion.
        if (ovenTimer > 10)
        {

            ovenActive = false;
            ovenTimer = 0;
            ovenComplete = true;
            ovenComplete2 = true;


        }

        transform.position = location;

    }
}
