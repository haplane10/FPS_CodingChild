using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AnimationController animationController;
    public new Rigidbody rigidbody;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animationController.PlayBoolAnim("Mode");
        }

        var dirX = Input.GetAxis("Horizontal");
        var dirY = Input.GetAxis("Vertical");
        if (dirX != 0 || dirY != 0)
        {
            animationController.PlayBoolAnim("Move",true);
            rigidbody.velocity = (transform.forward * dirY + transform.right * dirX).normalized * speed * Time.deltaTime;
        }
        else
        {
            animationController.PlayBoolAnim("Move", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            animationController.PlayTriggerAnim("Motion");
        }
    }
}
