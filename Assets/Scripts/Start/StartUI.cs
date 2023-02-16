using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // OnBtnClick과 연결되는 명사
    public BtnType currentType;

    // 버튼이 클릭이 안되더라도 Raycast와 충돌했을 때 크기가 변하게 한다
    public Transform buttonScale;

    Vector3 defaultScale;

    // 캔버스 그룹을 인식하게 해준다
    // 버튼을 누르면 캔버스가 오픈되거나 클로즈 되게 만든다
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    // 버튼을 클릭하면 버튼 의미에 맞게 디버그 로그가 나온다
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // 새게임
            case BtnType.NewGame:
                break;

            // 계정 생성 체크 버튼
            case BtnType.Check:
                Debug.Log("CreatCheck");
                break;

            // 계정 생성 맞습니다 버튼
            case BtnType.NameCheckYes:
                //SceneLoader.LoadSceneHandle
                Debug.Log("Yes");
                break;

            // 계정 생성 아닙니다 버튼
            case BtnType.NameCheckNo:

                Debug.Log("No");
                break;

            // 불러오기
            case BtnType.Load:

                break;

            // 불러오기 파일 체크
            case BtnType.FileCheck:

                break;

            // 이 저장 파일을 불러올 것이다
            case BtnType.FileCheckYes:

                break;

            // 이 저장 파일을 불러오지 않는다
            case BtnType.FileCheckNo:

                break;

            // 나가기
            case BtnType.Exit:

                Debug.Log("Exit");
                break;

            // 게임 종료 Yes 버튼
            case BtnType.GameExitYes:
                Application.Quit();
                Debug.Log("GameSleep");
                break;

            // 게임 종료 No 버튼
            case BtnType.GameExitNo:

                Debug.Log("I'm play go now");
                break;


        }
    }

    // 캔버스가 켜지는 기능
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    // 캔버스가 꺼지는 기능
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }


    // IPointerEnterHandler를 추가하려면 이것을 써야한다.
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}