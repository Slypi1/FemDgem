using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogs", menuName = "Dialogs/NormalDialog")]
public class DialogStandartSetting :ScriptableObject
{
    [SerializeField] private List<DialogDate> _dialogDates;
    [SerializeField] private Dialog _startTutorial;
    [SerializeField] private Dialog _exitTutorial;
    public List<DialogDate> DialogDates => _dialogDates;

    public List<Dialog> GetStartDialog()
    {
        var dialog = _dialogDates[0].Dialog;
        return dialog;
    }

    public List<Dialog> GetEndDialogs()
    {
        var dialog = _dialogDates[1].Dialog;
        return dialog;
    }

    public Dialog StartTutorial => _startTutorial;
    public Dialog ExitTutorial => _exitTutorial;

    [Serializable]
    public class DialogDate
    {
        public string Name;
        public List<Dialog> Dialog;
    }
    
    [Serializable]
    public class Dialog
    {
        public string Name;
        public string Replica;
    }
    
}
