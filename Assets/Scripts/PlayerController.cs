using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerType type;
    public AnimationController animationController;
    public new Rigidbody rigidbody;
    public float speed;

    // Jump
    public float jumpPower;
    public bool isGround;

    // Camera
    public Transform headTarget;
    public float rotSensitivity;

    // Shot
    public Transform shotParent;
    public GameObject shotPrefab;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == PlayerType.FirstCam) //if ((int)type == 1) 
        {  
            transform.localEulerAngles = Camera.main.transform.localEulerAngles.y * Vector3.up;
        }
        else
        {
            transform.localEulerAngles = Camera.main.transform.localEulerAngles.y * Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animationController.PlayBoolAnim("Mode");
        }

        var dirX = Input.GetAxis("Horizontal");
        var dirY = Input.GetAxis("Vertical");
        if (dirX != 0 || dirY != 0)
        {
            animationController.PlayBoolAnim("Move",true);
            rigidbody.velocity = (transform.forward * dirY + transform.right * dirX).normalized * speed * Time.deltaTime + (Vector3.up * rigidbody.velocity.y);
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

    public void Shot()
    {
        Instantiate(shotPrefab, shotParent.position, shotParent.rotation);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), transform.TransformDirection(Vector3.down), out hit, 0.6f))
        {
            //Debug.Log(hit.distance);
            Debug.DrawRay(transform.position + (Vector3.up * 0.1f), transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            if (!isGround)
            {
                isGround = true;
                animationController.PlayTriggerAnim("JumpEnd");
            }
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position + (Vector3.up * 0.1f), transform.TransformDirection(Vector3.down) * 0.6f, Color.white);
            isGround = false;
        }

        if (!animationController.GetBool("IsJump") && isGround && Input.GetAxisRaw("Jump") != 0)
        {
            animationController.PlayTriggerAnim("JumpIn");
            rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime);
        }

        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        headTarget.rotation *= Quaternion.AngleAxis(mouseX * rotSensitivity, Vector3.up);
        headTarget.rotation *= Quaternion.AngleAxis(-mouseY * rotSensitivity, Vector3.right);

        var angle = headTarget.eulerAngles;
        angle.x = MathFunctions.ClampAngle(angle.x);
        headTarget.eulerAngles = new Vector3(Mathf.Clamp(angle.x, -60, 60), angle.y, 0);
    }
}

public enum PlayerType
{
    None = 0,
    FirstCam = 1,
    ThirdCam = 2
}
