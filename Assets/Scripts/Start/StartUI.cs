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

    // ĵ���� �׷��� �ν��ϰ� ���ش�
    // ��ư�� ������ ĵ������ ���µǰų� Ŭ���� �ǰ� �����
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

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
                break;

            // ���� ���� üũ ��ư
            case BtnType.Check:
                Debug.Log("CreatCheck");
                break;

            // ���� ���� �½��ϴ� ��ư
            case BtnType.NameCheckYes:
                //SceneLoader.LoadSceneHandle
                Debug.Log("Yes");
                break;

            // ���� ���� �ƴմϴ� ��ư
            case BtnType.NameCheckNo:

                Debug.Log("No");
                break;

            // �ҷ�����
            case BtnType.Load:

                break;

            // �ҷ����� ���� üũ
            case BtnType.FileCheck:

                break;

            // �� ���� ������ �ҷ��� ���̴�
            case BtnType.FileCheckYes:

                break;

            // �� ���� ������ �ҷ����� �ʴ´�
            case BtnType.FileCheckNo:

                break;

            // ������
            case BtnType.Exit:

                Debug.Log("Exit");
                break;

            // ���� ���� Yes ��ư
            case BtnType.GameExitYes:
                Application.Quit();
                Debug.Log("GameSleep");
                break;

            // ���� ���� No ��ư
            case BtnType.GameExitNo:

                Debug.Log("I'm play go now");
                break;


        }
    }

    // ĵ������ ������ ���
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    // ĵ������ ������ ���
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
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