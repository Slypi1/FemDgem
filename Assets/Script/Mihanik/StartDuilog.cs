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
    [SerializeField] private DialogStandartSetting _dialogBossOffice;
    [SerializeField] private TMP_Text _nameOffice;
    [SerializeField] private TMP_Text _dialogTextOffice;
    private List<DialogStandartSetting.Dialog> _dialogOffice;
    private int _indexOffice;
    
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
        }
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
}
