using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //�� ��ũ��Ʈ�� ���߻���� �ް� �ִ�

    // OnBtnClick�� ����Ǵ� ���
    public SaveBtnType currentType;

    // ��ư�� Ŭ���� �ȵǴ��� Raycast�� �浹���� �� ũ�Ⱑ ���ϰ� �Ѵ�
    public Transform buttonScale;

    Vector3 defaultScale;

    private void Start()
    { defaultScale = buttonScale.localScale; }

    // ��ư�� Ŭ���ϸ� ��ư �ǹ̿� �°� ����� �αװ� ���´�
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // ������
            case SaveBtnType.Save:
                Debug.Log("Save");
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    { buttonScale.localScale = defaultScale * 1.2f; }

    public void OnPointerExit(PointerEventData eventData)
    { buttonScale.localScale = defaultScale; }
}
