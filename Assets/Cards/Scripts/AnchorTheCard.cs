using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.EventSystems;

public class AnchorTheCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // позиция перед началом перетаскивания
    private Vector3 startPosition;

    // Перетаскиваемая карта
    private Transform draggedCard;
    

    
    public void OnBeginDrag(PointerEventData eventData)//выполняется единажды, при начале перетаскивания объекта
    {
        startPosition = transform.position;
        draggedCard = transform;
        // Перенесите карту выше других объектов, чтобы она не была скрыта
        draggedCard.SetAsLastSibling();

    }

    public void OnDrag(PointerEventData eventData)// каждый кадр пока тянем объект 
    {
        draggedCard.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)// единажды когда отпустим объект 
    {
        //todo
    }

}
