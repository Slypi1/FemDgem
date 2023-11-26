using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OfficUIManager : MonoBehaviour
{
   [SerializeField] private Image _showPopup;
   [SerializeField] private TMP_Text _name;
   [SerializeField] private TMP_Text _dialogText;
   [SerializeField] private AudioClip _girlDiolog;
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private Image _diologPanel;
   [SerializeField] private DialogStandartSetting _dialogStandartSetting;
   private List<DialogStandartSetting.Dialog> _dialogs = new List<DialogStandartSetting.Dialog>();
   private int _index;

   public Action OnOpenFile;
   public Action OnOpenWatch;
   public Action OnShowClose;
   public void ShowPopup() =>   _showPopup.gameObject.SetActive(true);

   private void Start()
   {
      _audioSource.clip = _girlDiolog;
      _audioSource.Play();
      _index = 0;
      _dialogs = _dialogStandartSetting.GetFirstDialogZeta();
      TypeLine();
   }

   public void OnShowFile()
   {
      ShowPopup();
      OnOpenFile();
   }
   public void OnShowWatch()
   {
      ShowPopup();
      OnOpenWatch();
   }

   public void OnClose()
   {
      OnShowClose();
      _showPopup.gameObject.SetActive(false);
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
         _diologPanel.gameObject.SetActive(false);
      }
   }
}
