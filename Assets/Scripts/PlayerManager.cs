using System.Collections; //네임스페이스 소속
using System.Collections.Generic;
using UnityEngine;

//public 접근연산자
public class PlayerManager : MonoBehaviour
{
    Rigidbody playerRb;
    Camera playerCm;
    float playerSpeed = 10f;
    float mouseSpeed = 10f;
    void Start()
    {
        //rigidbody = 물리효과
        playerRb = GetComponent<Rigidbody>();
        playerCm = Camera.main;
    }
    void Update()
    {
        PlayerMove();
        PlayerCamera();
    }

    void PlayerMove()
    {
        //var 자동 자료형 지정
        var dirX = Input.GetAxis("Horizontal");
        var dirZ = Input.GetAxis("Vertical");
        //move
        if (dirX != 0 || dirZ != 0)
        {
            //playerRb.AddForce(dirX*playerSpeed,0,dirZ*playerSpeed);
            Vector3 vectorX = transform.TransformDirection(Vector3.right);      //(1,0,0) 월드좌표를 기준으로
            Vector3 vectorZ = transform.TransformDirection(Vector3.forward);    //(0,0,1)
            Vector3 moveMent = vectorZ*dirZ*playerSpeed+vectorX*dirX*playerSpeed;
            playerRb.velocity = moveMent;
        }
        //X,Y좌표 출력
        Debug.Log("X값:" + dirX);
        Debug.Log("Z값:" + dirZ);
    }
    void PlayerCamera()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        //playerCm.transform.localRotation = Quaternion.Euler(mouseX * mouseSpeed, mouseY * mouseSpeed, 0);
        //마우스 좌표 출력
        //Debug.Log("마우스X:" + mouseX);
        //Debug.Log("마우스Y:" + mouseY);
    }

    private void LateUpdate()
    {
        //두 벡터를 구성 요소별로 곱합니다
        Vector3 playerRotate = Vector3.Scale(playerCm.transform.forward, new Vector3(1, 0, 1));
        //Slerp 보간 곡선 - 시작값과 목적지에 값을 예측
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime*5f);
    }
}
