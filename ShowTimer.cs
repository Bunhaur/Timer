using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class ShowTimer : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    
    private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _timer.TimeIsChanged += Show;
    }

    private void OnDisable()
    {
        _timer.TimeIsChanged -= Show;
    }

    private void Show(int time)
    {
        _timerText.text = time.ToString();
    }
}
