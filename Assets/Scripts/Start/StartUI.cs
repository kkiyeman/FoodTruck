using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // OnBtnClick�� ����Ǵ� ���
    public BtnType currentType;

    // ��ư�� Ŭ���� �ȵǴ��� Raycast�� �浹���� �� ũ�Ⱑ ���ϰ� �Ѵ�
    public Transform buttonScale;

    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    // ��ư�� Ŭ���ϸ� ��ư �ǹ̿� �°� ����� �αװ� ���´�
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // ������
            case BtnType.NewGame:
                Debug.Log("NewGame");
                break;

            // �ҷ�����
            case BtnType.Load:
                Debug.Log("Load");
                break;

            // ������
            case BtnType.Exit:
                Debug.Log("Exit");
                break;
        }
    }

    // IPointerEnterHandler�� �߰��Ϸ��� �̰��� ����Ѵ�.
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
