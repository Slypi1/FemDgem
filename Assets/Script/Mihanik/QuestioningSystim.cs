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
   [SerializeField] private List<AudioClip> _audioClips;
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private TMP_Text _dialogText;
   [SerializeField] private TMP_Text _name;
   [SerializeField] private Image _icon;
   [SerializeField] private float _speedText;
   [SerializeField] private Image _sprite;
   private List<DialogSetting.Dialog> _dialogs;
   [SerializeField]private Quests _prefab;
   [SerializeField]private Transform _transformParent;
   [SerializeField] private Image _officeGG;
   [SerializeField] private Image _corridor;
   [SerializeField] private Image _dopros;
   [SerializeField] private Animator _animator;
   private List<DialogSetting.Question> questions = new List<DialogSetting.Question>();
   private string _diolog;
   private int _index;
   private string _namePer;
   private List<string> _question = new List<string>();
   public static Action<bool,int, string, bool> OnFalse;
   private string _que;
   private bool _lieF;
   private static int _clip;
   private bool _isTwoDialog;
   private void OnEnable()
   {
      File.OnNameHiro += StartQuestioning;
      File.OnNameTwoDialod += TwoDialod;
      Quests.OnQuestion += StartDialog;
   }
   private void OnDisable()
   {
      File.OnNameHiro -= StartQuestioning;
      File.OnNameTwoDialod -= TwoDialod;
      Quests.OnQuestion -= StartDialog;
   }

   private void  StartQuestioning(string name)
   {
      _clip++;

      if (_clip == 3)
      {
         _clip = 0;
      }

      _audioSource.clip = _audioClips[_clip];
      _audioSource.Play();
      _icon.sprite = _dialogSetting.GetIcon(name);
      _namePer= name;

      if (!_isTwoDialog)
      {
         questions = _dialogSetting.GetQuestion(name);
      }
      else
      {
         questions = _dialogSetting.GetQuestionTwo(name);
      }

      ShowQuest();
      
   }

   private void  ShowQuest()
   {
      //questions = _dialogSetting.GetQuestion(_namePer);
      _sprite.GameObject().SetActive(true);
      if (_question.Count != questions.Count)
      {
         for (int i = 0; i < questions.Count; i++)
         {
            if (_question.Contains(questions[i].Quest))
            {
               _transformParent.GetChild(i).GetComponent<Quests>().gameObject.SetActive(false);
            }
            else
            {
               _transformParent.GetChild(i).GetComponent<Quests>().gameObject.SetActive(true);
               _transformParent.GetChild(i).GetComponent<Quests>().Setup(questions[i].Quest);
            }
         }
      }
      else
      {
         if (_dialogSetting.GetLocation(_namePer) == 0)
         {
            OnFalse(_lieF,0, _namePer, _isTwoDialog);
         }
         else
         {
            OnFalse(_lieF,1, _namePer, _isTwoDialog);
         }
         questions = new List<DialogSetting.Question>();
         _question = new List<string>();
         _audioSource.Stop();
         _dopros.gameObject.SetActive(false);
      }
   }
   private void StartDialog(string quest)
   {
      _que= quest;
      _question.Add(quest);
      _index = 0;
      _sprite.GameObject().SetActive(false);
      if (!_isTwoDialog)
      {
         _dialogs = _dialogSetting.GetDialogs(quest, _namePer);
      }
      else
      {
         _dialogs = _dialogSetting.GetTwoDialogs(quest, _namePer);
      }

      TypeLine();
   }

   private void TwoDialod(string name)
   {
      _audioSource.clip = _audioClips[_audioClips.Count -1];
      _audioSource.Play();
      _icon.sprite = _dialogSetting.GetIcon(name);
      _namePer= name;
      questions = _dialogSetting.GetQuestionTwo(name) ;
      _isTwoDialog = true;
      ShowQuest();
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
         //_animator.SetFloat("IsFalse", 0);
         ShowQuest();
      }
   }
   
   private void TypeLine()
   {
      _dialogText.text = _dialogs[_index].Replica;
      _name.text = _dialogs[_index].Name;
      var lie = _dialogSetting.IsFalse(_namePer, _que, _dialogs[_index].Replica);
      _lieF = lie == 0
         ? false
         : true;
         //_animator.SetFloat("IsFalse", lie);
   }
}
