using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartBossOffice : MonoBehaviour
{
    [SerializeField] private DialogStandartSetting _dialogStandartSetting;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private AudioClip _bossOffice;
    [SerializeField] private AudioClip _bossOfficeDialog;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _panelDialog;
    [SerializeField] private Image _file;
    [SerializeField] private Image _filePopup;
    [SerializeField] private Image _tutor;
    [SerializeField] private Image _nextButton;
    [SerializeField] private Image _officegg;
    private List<DialogStandartSetting.Dialog> _dialogs = new List<DialogStandartSetting.Dialog>();
    private int _index;


    private void OnEnable()
    {
        TImeText.StartDiologBoss += StartDialogBoss;
    }

    private void OnDisable()
    {
        TImeText.StartDiologBoss -= StartDialogBoss;
    }

    private void Start()
    {
        _audioSource.clip = _bossOffice;
        _audioSource.Play();
        _name.text = _dialogStandartSetting.StartTutorial.Name;
        _dialogText.text = _dialogStandartSetting.StartTutorial.Replica;
        StartCoroutine(FileActiv());
    }

    IEnumerator FileActiv()
    {
        yield return new WaitForSeconds(2f);
        _file.gameObject.SetActive(true);
        _name.text = _dialogStandartSetting.StartTutorial.Name;
        _dialogText.text = _dialogStandartSetting.ExitTutorial.Replica;
        StartCoroutine(PanelDialogClose());
    }

    IEnumerator PanelDialogClose()
    {
        yield return new WaitForSeconds(2f);
        _panelDialog.gameObject.SetActive(false);
        _file.raycastTarget = true;
    }

    public void OnFile()
    {
       _filePopup.gameObject.SetActive(true);
    }

    public void OnStartTutor()
    {
        _filePopup.gameObject.SetActive(false);
        _tutor.gameObject.SetActive(true);
    }

    private void StartDialogBoss()
    {
        _nextButton.gameObject.SetActive(true);
        _dialogText.text = string.Empty;
        _name.text = string.Empty;
        _audioSource.clip = _bossOfficeDialog;
        _audioSource.Play();
        _dialogs = _dialogStandartSetting.GetEndDialogs();
        _index = 0;
        TypeLine();
    }
    private void  TypeLine()
    {
        _dialogText.text = _dialogs[_index].Replica;
        _name.text = _dialogs[_index].Name;
    }

    public void OnNextDialod()
    {
        _dialogText.text = string.Empty;
        _name.text = string.Empty;
        if (_index < _dialogs.Count - 1)
        {
            _index++;
            TypeLine();
        }
        else
        {
            _audioSource.Stop();
            _officegg.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
