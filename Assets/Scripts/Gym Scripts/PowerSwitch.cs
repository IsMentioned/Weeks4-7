/*Add another sprite to the scene. Write a script that:
 Uses a variable for speed
 In Update makes the sprite rotate by adding the speed to the Z component of its euler angle
 Has a public function StartSpin that sets the speed to 100
 Has a public function StopSpin that sets the speed to 0
Use the ON button’s OnClick list to call this script’s StartSpin() function, & OFF to call StopSpin(
*/

using UnityEngine;
using UnityEngine.UIElements;

public class PowerSwitch : MonoBehaviour
{
    float speed;
    Vector3 rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.eulerAngles;
        rotation.z += speed;
        transform.eulerAngles = rotation;
    }

    public void StartSpin()
    {
        speed = 100;
    }
    public void StopSpin()
    {
        speed = 0;
    }
}

