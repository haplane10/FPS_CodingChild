using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigid : MonoBehaviour
{
    new Rigidbody rigidbody;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var dirX = Input.GetAxis("Horizontal");
        var dirZ = Input.GetAxis("Vertical");

        if (dirX != 0 || dirZ != 0)
        {
            rigidbody.velocity = ((dirX * transform.right) + (dirZ * transform.forward)).normalized * speed;
        }
    }
}
