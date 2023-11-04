using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Arrow : MonoBehaviour, IPointerClickHandler,IPointerExitHandler
{
    [SerializeField] private Image _smallArrow;
    
    private void Start()
    {
        throw new NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var rotation = _smallArrow.GetComponent<RectTransform>().rotation;
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
