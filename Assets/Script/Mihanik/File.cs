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
    [SerializeField] private Button _doprosButton;
    private List<int> idx = new List<int>();
    private List<int> _twoDopros = new List<int>(){2,0,3};
    public static Action<string> OnNameHiro;
    public static Action<string> OnNameTwoDialod;

    private int _current;

    private void OnEnable()
    {
        ShowPopupManager.OnStart += OffButton;
    }

    private void OnDisable()
    {
        ShowPopupManager.OnStart -= OffButton;
    }

    private void Start()
    {
        _file.sprite = profiles[0].Icon;
        _name.text = profiles[0].Nickname;
        
    }

    private void OffButton()
    {
        if (idx.Count != profiles.Count)
        {
            if (idx.Contains(_current))
            {
                _file.sprite = profiles[_current].IconAfteDopros;
                _doprosButton.gameObject.SetActive(false);
            }
        }
        else
        {
            _file.sprite = profiles[_twoDopros[0]].IconAfteDopros;
            _name.text = profiles[_twoDopros[0]].Nickname;
        }
    }
    public void OnQuestioning()
    {
        if (idx.Count != profiles.Count)
        {
            _dopros.gameObject.SetActive(true);
            OnNameHiro(_name.text);
            _file.sprite = profiles[_current].IconAfteDopros;
            idx.Add(_current);
        }
        else
        {
            _dopros.gameObject.SetActive(true);
            OnNameTwoDialod(_name.text);
        }
        
        _officeGG.gameObject.SetActive(false);
        _showPopup.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void NextFile()
    {
        _current++;
        if (idx.Count != profiles.Count)
        {
            if (_current >= profiles.Count)
            {
                _current = 0;
            }

            _file.sprite = profiles[_current].Icon;

            _doprosButton.gameObject.SetActive(true);

            if (idx.Contains(_current))
            {
                _file.sprite = profiles[_current].IconAfteDopros;
                _doprosButton.gameObject.SetActive(false);
            }
        }
        else
        {
            if (_current >= _twoDopros.Count)
            {
                _current = 0;
            }
            _file.sprite = profiles[_current].IconAfteDopros;
        }
        _name.text = profiles[_current].Nickname;

    }

    public void OnClose()
    {
        _popupShow.gameObject.SetActive(false);
    }
}
