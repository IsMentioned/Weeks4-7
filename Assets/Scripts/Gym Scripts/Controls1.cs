using UnityEngine;

public class Controls1 : MonoBehaviour
{
    Vector3 oddball = new Vector3(0,0,0);
    public AudioSource buttonSound;
    public AudioSource sliderSound;

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
        //play a sound
        buttonSound.Play();

    }

    public void RotationChange(float input)
    {
        if(oddball.z != input)
        {
            //play a sound
            sliderSound.Play();
        }
        
        oddball = transform.eulerAngles;
        oddball.z = input;
        transform.eulerAngles = oddball;

    }
}

