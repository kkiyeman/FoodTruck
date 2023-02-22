using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //이 스크립트는 다중상속을 받고 있다

    // OnBtnClick과 연결되는 명사
    public BtnType currentType;

    // 버튼이 클릭이 안되더라도 Raycast와 충돌했을 때 크기가 변하게 한다
    public Transform buttonScale;

    Vector3 defaultScale;

    // 캔버스 그룹을 인식하게 해준다
    // 버튼을 누르면 캔버스가 오픈되거나 클로즈 되게 만든다
    public CanvasGroup nowGroup;
    public CanvasGroup nextGroup;


    private void Start()
    {
        if(buttonScale)
            defaultScale = buttonScale.localScale;
    }

    // 버튼을 클릭하면 버튼 의미에 맞게 디버그 로그가 나온다
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // 새게임
            case BtnType.NewGame:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("NewGame");
                break;

            // 계정 생성 체크 버튼
            case BtnType.Check:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("CreatCheck");
                break;

            // 계정 생성 확인 버튼
            case BtnType.NameCheckYes:
                //SceneLoader.LoadSceneHandle("Play", 0);
                Debug.Log("Yes");
                break;

            // 계정 생성 취소 버튼
            case BtnType.NameCheckNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Cancel");
                break;

            // 계정 생성 뒤로가기 버튼
            case BtnType.NameCheckBackStep:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("BackStep");
                break;

            // 불러오기
            case BtnType.Load:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Load");
                break;

            // 불러오기 파일 체크
            case BtnType.FileSlot:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("LoadCheck");
                break;

            // 불러오기 파일 체크
            case BtnType.Back:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Back");
                break;

            // 이 저장 파일을 불러올 것이다
            case BtnType.FileCheckYes:
                Debug.Log("Yes");
                break;

            // 이 저장 파일을 불러오지 않는다
            case BtnType.FileCheckNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Cancel");
                break;

            // 나가기
            case BtnType.Exit:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("Exit");
                break;

            // 게임 종료 Yes 버튼
            case BtnType.GameExitYes:
                Application.Quit();
                Debug.Log("GameSleep");
                break;

            // 게임 종료 No 버튼
            case BtnType.GameExitNo:
                CanvasGroupOn(nextGroup);
                CanvasGroupOff(nowGroup);
                Debug.Log("I'm play go now");
                break;


        }
    }

    // 캔버스가 켜지는 기능
    public void CanvasGroupOn(CanvasGroup cg)
    {
        if (cg == null)
            return;

        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;


    }

    // 캔버스가 꺼지는 기능
    public void CanvasGroupOff(CanvasGroup cg)
    {
        if (cg == null)
            return;

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

    }


    // IPointerEnterHandler를 추가하려면 이것을 써야한다.
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