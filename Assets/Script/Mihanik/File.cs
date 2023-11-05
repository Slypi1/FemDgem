using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class File : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;

    public static Action<string> OnNameHiro;


    public void OnQuestioning()
    {
        OnNameHiro(_name.text);
        gameObject.SetActive(false);
    }
}
