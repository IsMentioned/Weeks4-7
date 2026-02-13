using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Tank : MonoBehaviour
{
    Vector3 location;
    float speed = 0f;
    Vector3 mousePos;
    Camera main;
    Vector3 aim;
    public Transform turretAim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        location = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5f;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            location.x += speed * Time.deltaTime;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            location.x -= speed * Time.deltaTime;
        }

        transform.position = location;
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 aim = mousePos - location;

        turretAim.up = aim;

        
    }

}
