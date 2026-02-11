using UnityEngine;

public class Controls1 : MonoBehaviour
{
    Vector3 oddball = new Vector3();

    SpriteRenderer state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColourChange()
    {
        state.color = Random.ColorHSV();

    }

    public void RotationChange(float input)
    {
        oddball = transform.eulerAngles;
        oddball.z = input;
        transform.eulerAngles = oddball;
    }
}

