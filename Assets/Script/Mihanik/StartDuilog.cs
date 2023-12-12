using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartDuilog : MonoBehaviour
{
    [Header("Start")]
    [SerializeField] private DialogStandartSetting _dialogStandartSetting;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private AudioClip _corridor;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _bossOffice;
    [SerializeField] private Image _button;
    [SerializeField] private Image _girl;
    [SerializeField] private Image _corridorImage;
    [SerializeField] private Sprite _fullCorridor;
    private List<DialogStandartSetting.Dialog> _dialog;
    private int _index;
    
    
    private int _indexOffice;
    public static Action OnStartTutor;

    private void Start()
    {
        _audioSource.clip = _corridor;
        _audioSource.Play();
        _dialog = _dialogStandartSetting.GetStartDialog();
        _index = 0;
        TypeLine();
    }
    
    
    public void OnNextDialod()
    {
        _dialogText.text = string.Empty;
        _name.text = string.Empty;
        if (_index < _dialog.Count - 1)
        {
            _index++;
           TypeLine();
        }
        else
        {
            _audioSource.Stop();
            _bossOffice.gameObject.SetActive(true);
            _girl.gameObject.SetActive(true);
            _corridorImage.sprite = _fullCorridor;
            _button.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    public void StartTutor()
    {
        OnStartTutor();
    }
    private void  TypeLine()
    {
        _dialogText.text = _dialog[_index].Replica;
        _name.text = _dialog[_index].Name;
        
    }
}
