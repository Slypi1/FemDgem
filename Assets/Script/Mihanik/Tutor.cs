using UnityEngine;
using UnityEngine.UI;

public class Tutor : MonoBehaviour
{
    [SerializeField] private Image _tutor;
    [SerializeField] private Image _office;
    [SerializeField] private Image _bossOffice;
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
        _tutor.gameObject.SetActive(true);
    }

    public void GetWatc()
    {
        _bossOffice.gameObject.SetActive(false);
        _office.gameObject.SetActive(true);
    }
    
}
