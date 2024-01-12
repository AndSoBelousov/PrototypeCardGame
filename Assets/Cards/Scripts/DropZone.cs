using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {

                // Получите ссылку на перетаскиваемую карту
                var draggedCard = eventData.pointerDrag.GetComponent<Transform>();
                // Положить карту на это место
                draggedCard.SetParent(transform);
    }
}

