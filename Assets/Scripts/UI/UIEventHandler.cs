using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIEventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(OnBeginDragHandler != null)
            OnBeginDragHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }
}
