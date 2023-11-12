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
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _panelDialog;
    [SerializeField] private Image _file;
    [SerializeField] private Image _filePopup;
    [SerializeField] private Image _bossOfficeImage;
    [SerializeField] private Image _tutor;
    [SerializeField] private Image _girl;
    [SerializeField] private Sprite _noBoss;

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
        _girl.gameObject.SetActive(false);
        _bossOfficeImage.sprite = _noBoss;
        _filePopup.gameObject.SetActive(true);
    }

    public void OnStartTutor()
    {
        _tutor.gameObject.SetActive(true);
        _bossOfficeImage.gameObject.SetActive(false);
        _audioSource.Stop();
    }
}
