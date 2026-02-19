using UnityEngine;

public class Prefab : MonoBehaviour
{
    Vector3 randomRotate;
    Vector3 size;
    public UI uI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomRotate.z = Random.Range(0, 360);
        transform.eulerAngles = randomRotate;

    }

    // Update is called once per frame
    void Update()
    {

    }


}
