using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 버튼의 타입을 열거한다, 하나당 클래스가 된다
public enum BtnType
{
    NewGame,
    Check,
    NameCheckYes,
    NameCheckNo,
    Load,
    FileSlot,
    Back,
    FileCheckYes,
    FileCheckNo,
    Exit,
    GameExitYes,
    GameExitNo
}


public class StartManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.GetInstance().PlayBgm("Start");
    }
}