using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private List<Transform> cards = new List<Transform>();
    private bool _freeCell = true;
    private int _cardsOnTheBoard = 0;
    private float _cardOffset = 16;
    private float _animatiomSpeed = 5f;
    private bool _isMoving = false;
    public bool FreeCell
    {
        get { return _freeCell; } private set { ; }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(_cardsOnTheBoard <= 7)
        {
            //ссылка на перетаскиваемую карту
            var draggedCard = eventData.pointerDrag.GetComponent<Transform>();

            // ѕоложить карту на это место
            draggedCard.SetParent(transform);
            Vector3 newPosition = new Vector3(draggedCard.transform.localPosition.x, 0, 0);
            draggedCard.localPosition = newPosition;
            draggedCard.gameObject.GetComponent<Card>().State = CardStateType.OnTable;  //  измен€ем статус на столе

            cards.Add(draggedCard);
            _cardsOnTheBoard++;
            Debug.Log(" арт на столе: " + _cardsOnTheBoard);
        }
        else
        {
            Debug.Log(" арт на столе" + _cardsOnTheBoard);  
        }
    }

    

    void UpdateCardLayout()
    {
        int totalCards = cards.Count;
        if (totalCards == 0) return;

        float centerOffset = (totalCards - 1) * 0.5f * _cardOffset;

        for (int i = 0; i < totalCards; i++)
        {
            float targetX = i * _cardOffset - centerOffset;
            Vector3 targetPosition = new Vector3(targetX, 0, 0) + transform.position;
            cards[i].position = Vector3.Lerp(cards[i].position, targetPosition, _animatiomSpeed * Time.deltaTime);
        }
    }

   
    //IEnumerator UpdateCardLayout()
    //{
        
    //    float centerOffset = (totalCards - 1) * 0.5f * cardOffset;

    //    for (int i = 0; i < totalCards; i++)
    //    {
    //        float targetX = i * cardOffset - centerOffset;
    //        Vector3 targetPosition = new Vector3(targetX, 0, 0) + transform.localPosition;

    //        while (Vector3.Distance(cards[i].localPosition, targetPosition) > 0.01f)
    //        {
    //            cards[i].localPosition = Vector3.Lerp(cards[i].localPosition, targetPosition, speed * Time.deltaTime);
    //            yield return null;
    //        }
    //    }

    //    _isMoving = false;
    //}
}

