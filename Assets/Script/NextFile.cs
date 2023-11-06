using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextFile : MonoBehaviour
{
    [SerializeField] private List<Image> _file;
    [SerializeField] private OfficUIManager _of;
    private int idx = 0;
    
    private void OnEnable()
    {
        _of.OnOpenFile += Close;
    }

    
    private void Close()
    {
        for (int i = 1; i < _file.Count; i++)
        {
            _file[i].gameObject.SetActive(false);
        }

        idx = 0;
    }

    public void OnNextFile()
    {
        idx++;
       _file[idx].gameObject.SetActive(true);
    }
    
}
