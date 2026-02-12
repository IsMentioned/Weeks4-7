using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Enemy : MonoBehaviour
{
    SpriteRenderer omicron;
    public int health = 3;
    public TextMeshProUGUI number;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        omicron = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //is the mouse inside the sprite and was pressed this frame?
        if (omicron.bounds.Contains(mousePosition) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            health -= 1;
            number.text = health.ToString();
        }

        
    }
}
