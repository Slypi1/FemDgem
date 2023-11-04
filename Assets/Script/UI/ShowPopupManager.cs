using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPopupManager : MonoBehaviour
{
    [SerializeField] private Image _file;
    [SerializeField] private Image _watch;
    [SerializeField] private OfficUIManager _officPopup;
    private void OnEnable()
    {
        _officPopup.OnOpenFile += ShowFile;
        _officPopup.OnOpenWatch += ShowWatch;
        _officPopup.OnShowClose += Cloce;
    }

    private void OnDisable()
    {
        _officPopup.OnOpenFile -= ShowFile;
        _officPopup.OnOpenWatch -= ShowWatch;
        _officPopup.OnShowClose -= Cloce;
    }

    private void ShowFile()
    {
        _file.gameObject.SetActive(true);
    }

    public void ShowWatch()
    {
        _watch.gameObject.SetActive(true);
    }

    public void Cloce()
    {
        _file.gameObject.SetActive(false);
        _watch.gameObject.SetActive(false);
    }
}
