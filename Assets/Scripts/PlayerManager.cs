using System.Collections; //���ӽ����̽� �Ҽ�
using System.Collections.Generic;
using UnityEngine;

//public ���ٿ�����
public class PlayerManager : MonoBehaviour
{
    Rigidbody playerRb;
    Camera playerCm;
    float playerSpeed = 10f;
    float mouseSpeed = 10f;
    void Start()
    {
        //rigidbody = ����ȿ��
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
        //var �ڵ� �ڷ��� ����
        var dirX = Input.GetAxis("Horizontal");
        var dirZ = Input.GetAxis("Vertical");
        //move
        if (dirX != 0 || dirZ != 0)
        {
            //playerRb.AddForce(dirX*playerSpeed,0,dirZ*playerSpeed);
            Vector3 vectorX = transform.TransformDirection(Vector3.right);      //(1,0,0) ������ǥ�� ��������
            Vector3 vectorZ = transform.TransformDirection(Vector3.forward);    //(0,0,1)
            Vector3 moveMent = vectorZ*dirZ*playerSpeed+vectorX*dirX*playerSpeed;
            playerRb.velocity = moveMent;
        }
        //X,Y��ǥ ���
        Debug.Log("X��:" + dirX);
        Debug.Log("Z��:" + dirZ);
    }
    void PlayerCamera()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        //playerCm.transform.localRotation = Quaternion.Euler(mouseX * mouseSpeed, mouseY * mouseSpeed, 0);
        //���콺 ��ǥ ���
        //Debug.Log("���콺X:" + mouseX);
        //Debug.Log("���콺Y:" + mouseY);
    }

    private void LateUpdate()
    {
        //�� ���͸� ���� ��Һ��� ���մϴ�
        Vector3 playerRotate = Vector3.Scale(playerCm.transform.forward, new Vector3(1, 0, 1));
        //Slerp ���� � - ���۰��� �������� ���� ����
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime*5f);
    }
}
