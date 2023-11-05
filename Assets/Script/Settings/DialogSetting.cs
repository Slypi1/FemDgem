using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogs", menuName = "Dialogs/QuestionDialog")]
public class DialogSetting :ScriptableObject
{
    [SerializeField] private List<DialogDate> _dialogDates;

    public List<DialogDate> DialogDates => _dialogDates;
    
    public List<Dialog> GetDialogs(string name)
    {
        var dialogs = new List<Dialog>();

        dialogs = _dialogDates.Find(x => x.Name == name).Dialogs;

        return dialogs;
    }

    public Sprite GetIcon(string name)
    {
        var icon = _dialogDates.Find(x => x.Name == name).Icon;

        return icon;
    }
    
    [Serializable]
    public class DialogDate
    {
        public string Name;
        public Sprite Icon;
        public List<Dialog> Dialogs;
    }
    
    [Serializable]
    public class Dialog
    {
        public string Name;
        public string Replica;
    }
}
