using UnityEngine;
using UnityEngine.UIElements;

public class Flipper : MonoBehaviour
{
    private float direction = 0;
    public float speed;
    //private bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * transform.right * speed * Time.deltaTime;
    }
    /*public void OnMoveClick()
    {
        if (direction == 0)
        {
            direction = 1;
            active = true;
        }
    }

    public void OnStopClick()
    {
        if (direction == 1)
        {
            direction = -1;
            active = false;
        }
    }
    */
}


