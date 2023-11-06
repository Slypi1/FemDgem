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
    [SerializeField] private Image _bossOffice;
    [SerializeField] private Image _start;
    private List<DialogStandartSetting.Dialog> _dialog;
    [SerializeField]private float _speedText;
    private int _index;

    [Header("BossOffice")]
    [SerializeField] private TMP_Text _nameOffice;
    [SerializeField] private TMP_Text _dialogTextOffice;
    [SerializeField] private GameObject _dialogG;
    [SerializeField] private Image _girl;
    [SerializeField] private Image _offic;
    [SerializeField] private Image _newOffic;
    private List<DialogStandartSetting.Dialog> _dialogOffice;
    private DialogStandartSetting.Dialog _tutor;
    
    
    private int _indexOffice;
    public static Action OnStartTutor;

    private void Start()
    {
        _dialog = _dialogStandartSetting.GetStartDialog();
        _index = 0;
        StartCoroutine(TypeLine());
    }
    public void OnNextDialod()
    {
        _dialogText.text = string.Empty;
        _name.text = string.Empty;
        if (_index < _dialog.Count - 1)
        {
            _index++;
            StartCoroutine(TypeLine());
        }
        else
        { 
            _start.gameObject.SetActive(false);
           _bossOffice.gameObject.SetActive(true);
           _tutor = _dialogStandartSetting.StartTutorial;
           StartCoroutine(TypeTutor());
        }
    }

    public void StartTutor()
    {
        _girl.gameObject.SetActive(false);
        _offic.gameObject.SetActive(false);
        _newOffic.gameObject.SetActive(true);
        OnStartTutor();
    }
    IEnumerator TypeLine()
    {
        var dialog = _dialog[_index].Replica;
        _name.text = _dialog[_index].Name;
        foreach (var x in dialog.ToCharArray())
        {
            _dialogText.text += x;
            yield return new WaitForSeconds(_speedText);
        }
    }
    IEnumerator TypeTutor()
    {
        var dialog = _tutor.Replica;
        _name.text = _tutor.Name;
        foreach (var x in dialog.ToCharArray())
        {
            _dialogText.text += x;
            yield return new WaitForSeconds(_speedText);
        }
        _dialogG.SetActive(false);
    }
}
