using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharcater : MonoBehaviour
{
    private float moveSpeed = 1; //�̵��ӵ�
    private Vector3 vector;       
    
    public float MoveSpeed { get; set; }

    private CharacterController chaControl;  //�÷��̾� �̵� ��� ���� ������Ʈ

    private void Awake()
    {
        chaControl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        chaControl.Move(vector * Time.deltaTime);
        UpdateMove();
        UpdateRotate();
    }

    public void MoveTo(Vector3 direction)
    {
        //�̵� ���� = ĳ������ ȸ�� �� * ���� ��

        direction = Camera.main.transform.rotation * new Vector3(direction.x, direction.y, direction.z);

        //�̵� �� = �̵� ���� * �ӵ�
        vector = new Vector3(direction.x * moveSpeed, vector.y, direction.z * moveSpeed);
    }


    private void UpdateRotate()
    {
        
    }
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //�̵��� �� �� (�ȱ� or �ٱ�)

        
        MoveTo(new Vector3(x, 0, z));
    }

}
