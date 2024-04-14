using Cards;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private List<Transform> cards = new List<Transform>();
    private bool _freeCell = true;
    private int _cardsOnTheBoard = 0;
    private float _cardOffset = 17;
    private float _animationSpeed = 5f;
    public bool FreeCell
    {
        get { return _freeCell; } private set { ; }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_cardsOnTheBoard < 7)
        {
            _freeCell = true;
        }
        else _freeCell = false;

            //������ �� ��������������� �����
            var draggedCard = eventData.pointerDrag.GetComponent<Transform>();

            // �������� ����� �� ��� �����
            draggedCard.SetParent(transform);
            Vector3 newPosition = new Vector3(draggedCard.transform.localPosition.x, 0, 0);
            draggedCard.localPosition = newPosition;
            draggedCard.gameObject.GetComponent<Card>().State = CardStateType.OnTable;  //  �������� ������ �� �����

            if (cards.Count != 0)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (draggedCard.transform.localPosition.x < cards[i].transform.localPosition.x)
                    {
                        cards.Insert(i, draggedCard);
                        Debug.Log("����� ����� ������ �� �����" + i);
                        break;
                    }
                    else if (draggedCard.transform.localPosition.x > cards[i].transform.localPosition.x)
                    {
                        cards.Add(draggedCard);
                        break;
                    }
                 
                }
            }
            else cards.Add(draggedCard);

            //cards.Add(draggedCard);

             
            StartCoroutine(AnimateCardLayout());
            _cardsOnTheBoard++;
            //Debug.Log("���� �� �����: " + _cardsOnTheBoard);
        
    }

    

    IEnumerator AnimateCardLayout()
    {
        int totalCards = cards.Count;
        if (totalCards == 0) yield break;

        float centerOffset = (totalCards - 1) * 0.5f * _cardOffset;

        while (true)
        {
            for (int i = 0; i < totalCards; i++)
            {
                float targetX = i * _cardOffset - centerOffset;
                Vector3 targetPosition = new Vector3(targetX, 0, 0) + transform.position;
                cards[i].position = Vector3.Lerp(cards[i].position, targetPosition, _animationSpeed * Time.deltaTime);

            }

            yield return null;
        }
    }

    }

