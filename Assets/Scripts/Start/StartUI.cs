using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //�� ��ũ��Ʈ�� ���߻���� �ް� �ִ�

    // OnBtnClick�� ����Ǵ� ���
    public BtnType currentType;

    // ��ư�� Ŭ���� �ȵǴ��� Raycast�� �浹���� �� ũ�Ⱑ ���ϰ� �Ѵ�
    public Transform buttonScale;

    Vector3 defaultScale;

    // ĵ���� �׷��� �ν��ϰ� ���ش�
    // ��ư�� ������ ĵ������ ���µǰų� Ŭ���� �ǰ� �����
    public CanvasGroup nowGroup;
    public CanvasGroup nextGroup;


    private void Start()
    {
        if(buttonScale)
            defaultScale = buttonScale.localScale;
    }

    // ��ư�� Ŭ���ϸ� ��ư �ǹ̿� �°� ����� �αװ� ���´�
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // ������
            case BtnType.NewGame:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("NewGame");
                break;

            // ���� ���� üũ ��ư
            case BtnType.Check:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("CreatCheck");
                break;

            // ���� ���� Ȯ�� ��ư
            case BtnType.NameCheckYes:
                //SceneLoader.LoadSceneHandle("Play", 0);
                Debug.Log("Yes");
                break;

            // ���� ���� ��� ��ư
            case BtnType.NameCheckNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Cancel");
                break;

            // ���� ���� �ڷΰ��� ��ư
            case BtnType.NameCheckBackStep:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("BackStep");
                break;

            // �ҷ�����
            case BtnType.Load:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Load");
                break;

            // �ҷ����� ���� üũ
            case BtnType.FileSlot:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("LoadCheck");
                break;

            // �ҷ����� ���� üũ
            case BtnType.Back:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Back");
                break;

            // �� ���� ������ �ҷ��� ���̴�
            case BtnType.FileCheckYes:
                Debug.Log("Yes");
                break;

            // �� ���� ������ �ҷ����� �ʴ´�
            case BtnType.FileCheckNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Cancel");
                break;

            // ������
            case BtnType.Exit:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Exit");
                break;

            // ���� ���� Yes ��ư
            case BtnType.GameExitYes:
                Application.Quit();
                Debug.Log("GameSleep");
                break;

            // ���� ���� No ��ư
            case BtnType.GameExitNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("I'm play go now");
                break;


        }
    }

    // ĵ������ ������ ���
    public void CanvasGroupOn(CanvasGroup cg)
    {
        if (cg == null)
            return;

        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;


    }

    // ĵ������ ������ ���
    public void CanvasGroupOff(CanvasGroup cg)
    {
        if (cg == null)
            return;

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

    }


    // IPointerEnterHandler�� �߰��Ϸ��� �̰��� ����Ѵ�.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonScale)
            buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonScale)
            buttonScale.localScale = defaultScale;
    }
}