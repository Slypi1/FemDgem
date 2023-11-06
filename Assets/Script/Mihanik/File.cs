using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class File : MonoBehaviour
{
    [SerializeField] private List<ProfileSettings> profiles;
    [SerializeField] private TMP_Text _name;

    public static Action<string> OnNameHiro;

    private int _current;

    public void OnQuestioning()
    {
        var name = profiles[_current].Nickname;
        OnNameHiro(name);
        gameObject.SetActive(false);
    }

    public void NextFile()
    {
        _current++;
        if (_current >= profiles.Count)
            _current = 0;
    }
}
