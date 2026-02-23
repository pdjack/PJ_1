using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpSlider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        waveText.text = "Wave." + 1;
        ShowPlayerHpSlider(1);

    }

    public void UpdateWaveText(int waveCount)
    {
        waveText.text = "Wave." + waveCount.ToString();
    }

    public void ShowPlayerHpSlider(float hp)
    {
        hpSlider.value = hp;
    }
}
