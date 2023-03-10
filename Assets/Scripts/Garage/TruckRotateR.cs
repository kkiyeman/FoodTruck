using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TruckRotateR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float speed = 0.1f;
    private bool isBtnDown = false;
    [SerializeField] private GameObject truck;

    private void Update()
    {
        if (isBtnDown)
        {
            //AudioManager.GetInstance().PlaySfx("Tick");
            truck.gameObject.transform.Rotate(0f, (-1.5f) * speed, 0f, Space.Self);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

}
