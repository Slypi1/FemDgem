using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Arrow : MonoBehaviour,IBeginDragHandler,IDragHandler
{
    [SerializeField] private Image _smallArrow;
    public Vector3 mousePos, position;
    private Vector2 mousePosition;
    [SerializeField] private Image _officeBoss;
    [SerializeField] private Image _startoffic;
    public static Action _isWath;

    public void OnDrag(PointerEventData eventData)
    {
        var mouseCoord = new Vector2(Input.mousePosition.x - Screen.width / 2, Screen.height - Input.mousePosition.y - Screen.height / 2);
        
        var angle = Mathf.Atan2(mouseCoord.x,mouseCoord.y) * Mathf.Rad2Deg;
         Debug.Log(angle);
        _smallArrow.transform.Rotate(new Vector3(0, 0,  -angle), 2.5f);
        if (angle > -60f)
        {
            _officeBoss.gameObject.SetActive(true);
            _isWath();
        }
       /* Vector3 relative = transform.InverseTransformPoint(eventData.position);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        if (angle >= 45f)
        {
            angle += 10f;
        }
        var angleArrow = _smallArrow.GetComponent<RectTransform>().transform.rotation.z;
        _smallArrow.transform.Rotate(new Vector3(0, 0,  -angle), 2.5f);
        //var = Quaternion.Euler(0, 0,  angle);*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = eventData.position;
    }
}
