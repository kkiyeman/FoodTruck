using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharcater : MonoBehaviour
{
    private float moveSpeed = 1; //이동속도
    private Vector3 vector;       
    
    public float MoveSpeed { get; set; }

    private CharacterController chaControl;  //플레이어 이동 제어를 위한 컴포넌트

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
        //이동 방향 = 캐릭터의 회전 값 * 방향 값

        direction = Camera.main.transform.rotation * new Vector3(direction.x, direction.y, direction.z);

        //이동 힘 = 이동 방향 * 속도
        vector = new Vector3(direction.x * moveSpeed, vector.y, direction.z * moveSpeed);
    }


    private void UpdateRotate()
    {
        
    }
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //이동중 일 때 (걷기 or 뛰기)

        
        MoveTo(new Vector3(x, 0, z));
    }

}
