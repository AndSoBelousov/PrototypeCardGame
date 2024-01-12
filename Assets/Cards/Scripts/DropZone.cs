using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {

                // �������� ������ �� ��������������� �����
                var draggedCard = eventData.pointerDrag.GetComponent<Transform>();
                // �������� ����� �� ��� �����
                draggedCard.SetParent(transform);
    }
}

