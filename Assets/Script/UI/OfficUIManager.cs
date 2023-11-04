using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OfficUIManager : MonoBehaviour
{
   [SerializeField] private Image _showPopup;

   public Action OnOpenFile;
   public Action OnOpenWatch;
   public Action OnShowClose;
   public void ShowPopup() =>   _showPopup.gameObject.SetActive(true);
   
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
}
