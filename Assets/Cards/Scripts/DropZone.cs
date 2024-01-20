using Cards;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private bool _freeCell = true;

    public bool FreeCell
    {
        get { return _freeCell; } private set { ; }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(_freeCell != false)
        {
        //ссылка на перетаскиваемую карту
        var draggedCard = eventData.pointerDrag.GetComponent<Transform>();
        // Положить карту на это место
        draggedCard.SetParent(transform);
        draggedCard.localPosition = Vector3.zero;
        draggedCard.gameObject.GetComponent<Card>().State = CardStateType.OnTable;  //  изменяем статус на столе

        _freeCell = false;
        }
    }
}

