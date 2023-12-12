using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class File : MonoBehaviour
{
    [SerializeField] private List<ProfileSettings> profiles;
    [SerializeField] private Image _showPopup;
    [SerializeField] private Image _file;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _officeGG;
    [SerializeField] private Image _dopros;
    [SerializeField] private Image _popupShow;

    public static Action<string> OnNameHiro;

    private int _current;

    private void Start()
    {
        _file.sprite = profiles[0].Icon;
        _name.text = profiles[0].Nickname;
    }

    public void OnQuestioning()
    {
        _dopros.gameObject.SetActive(true);
        OnNameHiro(_name.text);
        _officeGG.gameObject.SetActive(false);
        _showPopup.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void NextFile()
    {
        _current++;
        if (_current >= profiles.Count)
        {
            _current = 0;
        }
        _file.sprite = profiles[_current].Icon;
        _name.text = profiles[_current].Nickname;
    }

    public void OnClose()
    {
        _popupShow.gameObject.SetActive(false);
    }
}
