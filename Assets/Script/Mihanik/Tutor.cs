using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tutor : MonoBehaviour
{
    [SerializeField] private Image _tutor;
    
    private void OnEnable()
    {
        StartDuilog.OnStartTutor += StartTutor;
    }

    private void OnDisable()
    {
        StartDuilog.OnStartTutor -= StartTutor;
    }

    private void  StartTutor()
    {
        
    }
}
