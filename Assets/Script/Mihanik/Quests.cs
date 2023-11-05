using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Quests : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _quest;
    [SerializeField] private Image _line;
    [SerializeField] private Image _allocation;

    public static Action<string> OnQuestion;
    public void Setup(string quest)
    {
        _quest.text = quest;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       _allocation.gameObject.SetActive(true);
       _line.gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _allocation.gameObject.SetActive(false);
        _line.gameObject.SetActive(true);
    }

    public void Question()
    {
        OnQuestion(_quest.text);
    }
}
