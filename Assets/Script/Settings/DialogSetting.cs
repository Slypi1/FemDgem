using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogs", menuName = "Dialogs/QuestionDialog")]
public class DialogSetting :ScriptableObject
{
    [SerializeField] private List<DialogDate> _dialogDates;
 
    public List<DialogDate> DialogDates => _dialogDates;
    
    public List<Dialog> GetDialogs(string quest, string name)
    {
        var dialogs = new List<Dialog>();
         var questions = _dialogDates.Find(x => x.Name == name).Questions;
         dialogs = questions.Find(x => x.Quest == quest).Dialogs;
        
        return dialogs;
    }
    public List<Dialog> GetTwoDialogs(string quest, string name)
    {
        var dialogs = new List<Dialog>();
        var questions = _dialogDates.Find(x => x.Name == name).TwoDialogs;
        dialogs = questions.Find(x => x.Quest == quest).Dialogs;
        
        return dialogs;
    }

    public Sprite GetIcon(string name)
    {
        Debug.Log(name);
        var icon = _dialogDates.Find(x => x.Name == name).Icon;

        return icon;
    }

    public int GetLocation(string name)
    {
        var number = _dialogDates.Find(x => x.Name == name).Location;
        return number;
    }

    public List<Dialog> GetAdterDiologs(string name)
    {
        var dioalod = _dialogDates.Find(x => x.Name == name).AfterDialogs;
        return dioalod;
    }
    public List<Dialog> GetEndDiologs(string name)
    {
        var dioalod = _dialogDates.Find(x => x.Name == name).EndDialogs;
        return dioalod;
    }
    
    public List<Question> GetQuestion(string name)
    {
        var questions = new List<Question>();
        questions = _dialogDates.Find(x => x.Name == name).Questions;

        return questions;
    }
    public List<Question> GetQuestionTwo(string name)
    {
        var questions = new List<Question>();
        questions = _dialogDates.Find(x => x.Name == name).TwoDialogs;

        return questions;
    }

    public float IsFalse(string name, string question, string diolog)
    {
       
       var questions = _dialogDates.Find(x => x.Name == name).Questions;
       var dialogs = questions.Find(x => x.Quest == question).Dialogs;
       var lie = dialogs.Find(x => x.Replica == diolog).Lie;
       return lie;
    }

    [Serializable]
    public class DialogDate
    {
        public string Name;
        public Sprite Icon;
        public List <Question> Questions;
        public int Location;
        public List<Dialog> AfterDialogs;
        public List<Dialog> EndDialogs;
        public List<Question> TwoDialogs;
    }
    
    [Serializable]
    public class Dialog
    {
        public string Name;
        public float Lie;
        public string Replica;
    }
    [Serializable]
    public class Question
    {
        public string Quest;
        public List<Dialog> Dialogs;
    }
}
