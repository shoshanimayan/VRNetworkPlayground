using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragWindow : Selectable, IPointerClickHandler, ISubmitHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [SerializeField] RectTransform dragged;
    [SerializeField]Canvas canvas;
    [SerializeField] TextMeshProUGUI text;

    Vector2 start;


    private void Start()
    {
      //  dragged = GetComponent<RectTransform>();
     //   canvas = transform.parent.GetComponent<Canvas>();
      //  text = GetComponent<TextMeshProUGUI>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        /*
        Debug.Log(eventData.position);
        Debug.Log(eventData.position - start);
        Vector2 move = new Vector2((eventData.position.x + start.x) * canvas.transform.localScale.x, (eventData.position.y - start.y) * canvas.transform.localScale.y);
        Debug.Log(move);
        dragged.gameObject.transform.localPosition = move;
         start = eventData.position;
        */
        //    dragged.anchoredPosition += eventData.delta/ canvas.scaleFactor;

    }


    public void OnEndDrag(PointerEventData eventData)
    {
        /*
        Debug.Log(eventData.position);
        Debug.Log(eventData.position - start);
        Vector2 move = new Vector2((eventData.position.x + start.x) * canvas.transform.localScale.x, (eventData.position.y - start.y) * canvas.transform.localScale.y);
        Debug.Log(move);
        dragged.gameObject.transform.localPosition = move;
        start = eventData.position;*/

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       // start = eventData.position;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        
       Debug.Log(this.gameObject.name + " Was Clicked.");
      start = eventData.position;
        Debug.Log(start);
        

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
         Debug.Log(eventData.position);
         Debug.Log(eventData.position - start);
           Vector2 move = new Vector2((eventData.position.x + start.x)*canvas.transform.localScale.x,( eventData.position.y - start.y) * canvas.transform.localScale.y);
        Debug.Log(move);
        move = new Vector2(dragged.gameObject.transform.localPosition.x + move.x, dragged.gameObject.transform.localPosition.y + move.y);
        dragged.gameObject.transform.localPosition = move;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

  

   

    public void OnSubmit(BaseEventData eventData)
    {
        Debug.Log("The cursor submitted");
    }

    // Start is called before the first frame update

}
