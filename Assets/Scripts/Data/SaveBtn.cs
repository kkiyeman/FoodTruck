using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //이 스크립트는 다중상속을 받고 있다

    // OnBtnClick과 연결되는 명사
    public SaveBtnType currentType;

    // 버튼이 클릭이 안되더라도 Raycast와 충돌했을 때 크기가 변하게 한다
    public Transform buttonScale;

    Vector3 defaultScale;

    private void Start()
    { defaultScale = buttonScale.localScale; }

    // 버튼을 클릭하면 버튼 의미에 맞게 디버그 로그가 나온다
    public void OnBtnClick()
    {
        switch (currentType)
        {
            // 새게임
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
