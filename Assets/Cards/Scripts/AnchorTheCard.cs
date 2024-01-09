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

    public void OnBeginDrag(PointerEventData eventData)//����������� ��������, ��� ������ �������������� �������
    {
        _offset = transform.position - _camera.ScreenToViewportPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)// ������ ���� ���� ����� ������ 
    {
        Vector3 newPos = _camera.ScreenToViewportPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)// �������� ����� �������� ������ 
    {
        throw new System.NotImplementedException(); // todo
    }

}
