using TMPro;
using UnityEngine;  
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

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

        draggedCard.gameObject.layer = LayerMask.NameToLayer("ignore");

    }

    public void OnDrag(PointerEventData eventData)// ������ ���� ���� ����� ������ 
    {
        
        draggedCard.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0)/ 8;

    }

    public void OnEndDrag(PointerEventData eventData)// �������� ����� �������� ������ 
    {
     
       
        // ���������, ���� �� ����, �� ������� ����� �������� �����
        if (eventData.pointerEnter != null)
        {

            // �������� ������ �� ����
            var dropZone = eventData.pointerEnter.GetComponent<DropZone>();
            
            // ���������, �������� �� ���� ���������� ������ ��� �����
            if (dropZone != null)
            {
                if (dropZone.FreeCell != false)
                {
                    Debug.Log("�����!!!!!");
                }
                else
                {
                    Debug.Log("������");
                }
                //draggedCard.SetParent(dropZone.transform);
                //draggedCard.localPosition = Vector3.zero;
            }
            else
            {
                // ������� ����� �� ��������� �������, ���� ���� �����������
                draggedCard.position = startPosition;
            }
            
        }
        else
        {
            // ������� ����� �� ��������� �������, ���� ���� �� ���� �������
            draggedCard.position = startPosition;
            Debug.Log("pointerEnter ����� null");
        }

        draggedCard.gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
