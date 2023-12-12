using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AfterDialod : MonoBehaviour
{
  [SerializeField] private DialogSetting _dialogSetting;
  [SerializeField] private TMP_Text  _dialogText;
  [SerializeField] private TMP_Text _name;
  private List<DialogSetting.Dialog> _dialogs = new List<DialogSetting.Dialog>();
  [SerializeField] private Image _officegg;
  [SerializeField] private Image _panelDioalog;
  private int _index;
  private string _namePerson;
  
  private void OnEnable()
  {
    QuestioningSystim.OnAftorDialog += StartDiolod;
  }

  private void OnDisable()
  {
    QuestioningSystim.OnAftorDialog += StartDiolod;
  }

  public void StartDiolod(string name)
  {
    if (_dialogSetting.GetLocation(name) == 1)
    {
      _panelDioalog.gameObject.SetActive(true);
    }
    _dialogs = _dialogSetting.GetAdterDiologs(name);
    
    _namePerson = name;
    _index = 0;
    TypeLine();
  }
  private void TypeLine()
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
      if (_dialogSetting.GetLocation(_namePerson) == 0)
      {
        _officegg.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
      }
      else
      {
        _panelDioalog.gameObject.SetActive(false);
      }
    }
  }
}
