using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI waveText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // UI는 보통 씬마다 새로 구성되므로 DontDestroyOnLoad는 생략하는 경우가 많습니다.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        waveText.text = "Wave." + 1;
    }

    public void UpdateWaveText(int waveCount)
    {
        waveText.text = "Wave." + waveCount.ToString();
    }
}
