using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class Spawner2 : MonoBehaviour
{
    Vector3 randomPos;
    public GameObject birdPrefab;
    Vector3 world; 
    public Camera main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        world = new Vector3(Screen.width, Screen.height, 0);
        world = main.ScreenToWorldPoint(world);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            randomPos = new Vector3(UnityEngine.Random.Range(-world.x, world.x), UnityEngine.Random.Range(-world.y, world.y), 0);
            Instantiate(birdPrefab, randomPos, Quaternion.identity);
        }
    }
}
