using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(transform.forward * power);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
