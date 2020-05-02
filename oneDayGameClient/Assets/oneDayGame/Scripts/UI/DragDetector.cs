using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDetector : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<PointerEventData> OnInitializePotentialDragCallback;

    public Action<PointerEventData> OnBeginDragCallback;

    public Action<PointerEventData> OnDragCallback;

    public Action<PointerEventData> OnEndDragCallback;

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        OnInitializePotentialDragCallback?.Invoke(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragCallback?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragCallback?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragCallback?.Invoke(eventData);
    }
}
