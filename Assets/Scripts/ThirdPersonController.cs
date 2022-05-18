using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Vector2 look;
    public float rotationPower = 3f;
    public Transform head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        head.rotation *= Quaternion.AngleAxis(look.x * rotationPower, Vector3.up);
        head.rotation *= Quaternion.AngleAxis(look.y * rotationPower, Vector3.right);
    }
}
