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
   [SerializeField]private Quests _prefab;
   [SerializeField]private Transform _transformParent;
   
   private string _diolog;
   private int index;
   private string _namePer;
   private List<string> _question = new List<string>();
   private void OnEnable()
   {
      File.OnNameHiro += StartQuestioning;
      Quests.OnQuestion += StartDialog;
   }
   private void OnDisable()
   {
      File.OnNameHiro -= StartQuestioning;
      Quests.OnQuestion -= StartDialog;
   }

   private void  StartQuestioning(string name)
   {
      _icon.sprite = _dialogSetting.GetIcon(name);
      _sprite.GameObject().SetActive(true);
      _namePer= name;
      ShowQuest();
   }

   private void  ShowQuest()
   {
      var questions = _dialogSetting.GetQuestion(_namePer);
      var idx = 0;
      if (_question.Count != questions.Count)
      {
         foreach (var question in questions)
         {
            if (_question.Contains(question.Quest))
               continue;
            
            _transformParent.GetChild(idx).GetComponent<Quests>().gameObject.SetActive(true);
            _transformParent.GetChild(idx).GetComponent<Quests>().Setup(question.Quest);
            idx++;
         }
      }
      else
      {
         _sprite.gameObject.SetActive(false);
      }
   }
   private void StartDialog(string quest)
   {
       _question.Add(quest);
       index = 0;
      _dialogs = _dialogSetting.GetDialogs(quest,_namePer);
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
      else
      {
         ShowQuest();
      }
   }
   
   IEnumerator TypeLine()
   {
      for (int i = 0; i < _transformParent.childCount; i++)
      {
         _transformParent.GetChild(i).gameObject.SetActive(false);
      }
      var dialog = _dialogs[index].Replica;
      _name.text = _dialogs[index].Name;
         foreach (var x in dialog.ToCharArray())
         {
            _dialogText.text += x;
            yield return new WaitForSeconds(_speedText);
         }
   }
}
