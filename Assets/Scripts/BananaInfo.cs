using UnityEngine;

public class BananaInfo : MonoBehaviour
{
    Vector3 location;
    SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer.bounds.Contains(location))
            {

        }
    }
}
