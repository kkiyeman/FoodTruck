using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hamburger
{
    public string Name { get; protected set; }
    public string[] Recipe { get; protected set; }

    public abstract void SetInfo();
}

public class Burger : Hamburger
{

    public Burger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�ܹ���";
        Recipe = new string[5]
        {
            "����",
            "�Ʒ���",
            "���",
            "�����",
            "�丶��"
        };
    }

}

public class CheeseBurger : Hamburger
{

    public CheeseBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ġ�����";
        Recipe = new string[6]
        {
            "����",
            "�Ʒ���",
            "���",
            "�����",
            "�丶��",
            "ġ��"
        };
    }
}

public class VeganBurger : Hamburger
{
    public VeganBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "��ǹ���";
        Recipe = new string[4]
        {
            "����",
            "�Ʒ���",
            "�����",
            "�丶��"
        };
    }
}

public class MeetBurger : Hamburger
{
    public MeetBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "������";
        Recipe = new string[4]
        {
            "����",
            "�Ʒ���",
            "���",
            "ġ��"
        };
    }
}

