using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.EventSystems;

public class AnchorTheCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // ������� ����� ������� ��������������
    private Vector3 startPosition;

    // ��������������� �����
    private Transform draggedCard;
    

    
    public void OnBeginDrag(PointerEventData eventData)//����������� ��������, ��� ������ �������������� �������
    {
        startPosition = transform.position;
        draggedCard = transform;
        // ���������� ����� ���� ������ ��������, ����� ��� �� ���� ������
        draggedCard.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)// ������ ���� ���� ����� ������ 
    {
        draggedCard.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)// �������� ����� �������� ������ 
    {
        //todo
    }

}
