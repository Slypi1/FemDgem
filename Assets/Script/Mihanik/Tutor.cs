using UnityEngine;
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
        _tutor.gameObject.SetActive(true);
    }
}
