using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ư�� Ÿ���� �����Ѵ�, �ϳ��� Ŭ������ �ȴ�
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