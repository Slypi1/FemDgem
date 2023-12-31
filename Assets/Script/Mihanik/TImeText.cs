using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TImeText : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private float _speedText;
    [SerializeField] private AudioClip _typewriter;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _corridor;
    [SerializeField] private Image _bossOffice;
    [SerializeField] private Image _officeGG;
    private const string START_TEXT = "17 ноября 1947 года" + "\n" + "18:30";
    
    private string _text;
    public static Action StartDiologBoss;
    public static Action<string> OnAfterDiolog;
    private void OnEnable()
    {
        Arrow.OnWath += NextTutor;
        QuestioningSystim.OnFalse += AfterDopros;
    }

    private void OnDisable()
    {
        Arrow.OnWath -= NextTutor;
        QuestioningSystim.OnFalse -= AfterDopros;
    }

    private void AfterDopros(bool isFalse, int location, string name)
    {
        if (!isFalse)
        {
            _audioSource.clip = _typewriter;
            _audioSource.Play();
            _text = "17 ноября 1947 года" + "\n" + "17:00";
            StartCoroutine(NextDiolog(location, name));
        }
        else
        {
            _audioSource.clip = _typewriter;
            _audioSource.Play();
            _text = "17 ноября 1947 года" + "\n" + "17:30";
            StartCoroutine(NextDiolog(location, name));
        }
    }
    void Start()
    {
        _audioSource.clip = _typewriter;
        _audioSource.Play();
        StartCoroutine(TypeLine());
    }
    

    IEnumerator TypeLine()
    {
        foreach (var x in START_TEXT.ToCharArray())
        {
            _timeText.text += x;
            yield return new WaitForSeconds((_audioSource.clip.channels -1)/START_TEXT.ToCharArray().Length);
        }

        StartCoroutine(Corridor());
    }

    IEnumerator Corridor()
    {
        yield return new WaitForSeconds(_audioSource.clip.channels);
        _audioSource.Stop();
        _corridor.gameObject.SetActive(true);
    }
    private void NextTutor(int i)
    {
        if (i == 0)
        {
            _audioSource.clip = _typewriter;
            _audioSource.Play();
            _text = "17 ноября 1947 года" + "\n" + "15:00";
            StartCoroutine(EndTutor());
        }
    }

    
    private IEnumerator NextDiolog(int location, string name)
    {
        _timeText.text = string.Empty;
        foreach (var x in _text.ToCharArray())
        {
            _timeText.text += x;
            yield return new WaitForSeconds((_audioSource.clip.channels -1)/_text.ToCharArray().Length);
        }
        StartCoroutine(NextLocation(location, name));
    }

    private IEnumerator NextLocation(int location, string name)
    {
        yield return new WaitForSeconds(_audioSource.clip.channels);
        _audioSource.Stop();
        if (location == 0)
        {
            _corridor.gameObject.SetActive(true);
            OnAfterDiolog(name);
        }
        else
        {
            _officeGG.gameObject.SetActive(true);
            OnAfterDiolog(name);
        }
    }
    IEnumerator EndTutor()
    {
        _timeText.text = string.Empty;
        foreach (var x in _text.ToCharArray())
        {
            _timeText.text += x;
            yield return new WaitForSeconds((_audioSource.clip.channels -1)/_text.ToCharArray().Length);
        }
        StartCoroutine(ToturEnd());
    }

    IEnumerator ToturEnd()
    {
        yield return new WaitForSeconds(_audioSource.clip.channels);
        _audioSource.Stop();
        _bossOffice.gameObject.SetActive(true);
        StartDiologBoss();
    }
}
