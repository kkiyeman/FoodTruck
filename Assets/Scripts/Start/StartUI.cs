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
                Debug.Log("NewGame");
                break;

            // 불러오기
            case BtnType.Load:
                Debug.Log("Load");
                break;

            // 나가기
            case BtnType.Exit:
                Debug.Log("Exit");
                break;
        }
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
