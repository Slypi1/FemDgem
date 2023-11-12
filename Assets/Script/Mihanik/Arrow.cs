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
    [SerializeField] private Image _bigArrov;
    public Vector3 mousePos, position;
    private Vector2 mousePosition;
    [SerializeField] private Image _tutor;
    [SerializeField] private AudioClip _watch;
    [SerializeField] private AudioSource _audioSource;
    
    public static Action <int> OnWath;

    public void Start()
    {
        _audioSource.clip = _watch;
        _audioSource.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var mouseCoord = new Vector2(Input.mousePosition.x - Screen.width / 2, Screen.height - Input.mousePosition.y - Screen.height / 2);
        
        var angle = Mathf.Atan2(mouseCoord.x,mouseCoord.y) * Mathf.Rad2Deg;
        
        _bigArrov.transform.Rotate(new Vector3(0, 0,  -angle), 2.5f);
        _smallArrow.transform.Rotate(new Vector3(0,0,-angle - 60f),5.0f);
       
        if (_bigArrov.GetComponent<RectTransform>().transform.rotation.z >= -0.7f)
        {
            _audioSource.Stop();
            OnWath(0);
            _tutor.gameObject.SetActive(false);
        }
        Debug.Log(_bigArrov.GetComponent<RectTransform>().transform.rotation.z);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = eventData.position;
    }
}
