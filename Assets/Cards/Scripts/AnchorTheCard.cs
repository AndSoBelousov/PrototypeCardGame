using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.EventSystems;

public class AnchorTheCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera _camera;
    private Vector3 _offset;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)//выполняется единажды, при начале перетаскивания объекта
    {
        _offset = transform.position - _camera.ScreenToViewportPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)// каждый кадр пока тянем объект 
    {
        Vector3 newPos = _camera.ScreenToViewportPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)// единажды когда отпустим объект 
    {
        throw new System.NotImplementedException(); // todo
    }

}
