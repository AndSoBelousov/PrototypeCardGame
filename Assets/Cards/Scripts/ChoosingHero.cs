using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ChoosingHero : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private GameObject _heroOnePlayer;
    [SerializeField]
    private GameObject _heroTwoPlayer;

    [SerializeField]
    private Sprite _currentSprite;

    private Vector3 _panelOne = new Vector3(-365, 70, 0);
    private Vector3 _panelTwo = new Vector3(-365, -70, 0);

    private bool _isPlayerOne = true;//!!!!!!!!!!!!! меняется только у текущей цели, понять как поменять у всех 

    private void Start()
    {
        if(_heroOnePlayer != null && _heroTwoPlayer != null)
        {
            //пока ничего
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isPlayerOne == true) 
        {
            
            _heroOnePlayer.GetComponent<SpriteRenderer>().sprite = _currentSprite;
            
            StartCoroutine(MovingIcon(eventData.pointerClick));
            Debug.Log("first click");
        }
        else
        {
            Debug.Log("next click");
            _heroTwoPlayer.GetComponent<SpriteRenderer>().sprite = _currentSprite;

            StartCoroutine(MovingIcon(eventData.pointerClick));
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.5f;
        transform.position += new Vector3(0f, 3f, 0f);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.5f;
        transform.position -= new Vector3(0f, 3f, 0f);
        
    }

    private IEnumerator MovingIcon(GameObject icon)
    {
        Vector3 startPos = icon.transform.localPosition;
        Vector3 endPos = _isPlayerOne == true ? _panelOne : _panelTwo;

        float time = 0;
        while(time < 1)
        {
            icon.transform.localPosition = Vector3.Lerp(startPos, endPos, time);
            time += Time.deltaTime;
            yield return null;
        }
        icon.GetComponent<ChoosingHero>().enabled = false;
    }
}
