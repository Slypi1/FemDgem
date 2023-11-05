using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestioningSystim : MonoBehaviour
{
   [SerializeField] private DialogSetting _dialogSetting;
   [SerializeField] private TMP_Text _dialogText;
   [SerializeField] private TMP_Text _name;
   [SerializeField] private Image _icon;
   [SerializeField] private float _speedText;
   [SerializeField] private Image _sprite;
   private List<DialogSetting.Dialog> _dialogs;
   private string _diolog;
   private int index;
   private void OnEnable()
   {
      File.OnNameHiro += StartQuestioning;
   }
   private void OnDisable()
   {
      File.OnNameHiro += StartQuestioning;
   }

   private void  StartQuestioning(string name)
   {
      _icon.sprite = _dialogSetting.GetIcon(name);
      _sprite.GameObject().SetActive(true);
      _dialogs = _dialogSetting.GetDialogs(name);
      index = 0;
      StartCoroutine(TypeLine());
   }

   public void OnNextDialod()
   {
      _dialogText.text = string.Empty;
      _name.text = string.Empty;
      if (index < _dialogs.Count - 1)
      {
         index++;
         StartCoroutine(TypeLine());
      }
   }
   
   IEnumerator TypeLine()
   {
      var dialog = _dialogs[index].Replica;
      _name.text = _dialogs[index].Name;
         foreach (var x in dialog.ToCharArray())
         {
            _dialogText.text += x;
            yield return new WaitForSeconds(_speedText);
         }
   }
}
