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

    public Sprite GetIcon(string name)
    {
        Debug.Log(name);
        var icon = _dialogDates.Find(x => x.Name == name).Icon;

        return icon;
    }

    public List<Question> GetQuestion(string name)
    {
        var questions = new List<Question>();
        questions = _dialogDates.Find(x => x.Name == name).Questions;

        return questions;
    }

    [Serializable]
    public class DialogDate
    {
        public string Name;
        public Sprite Icon;
        public List <Question> Questions;
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
