using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private GameObject gameOverPanel;

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
        gameOverPanel.SetActive(false);

    }

    // text ) waveCount
    public void UpdateWaveText(int waveCount)
    {
        waveText.text = "Wave." + waveCount.ToString();
    }

    // slider ) player hp
    public void ShowPlayerHpSlider(float hp)
    {
        hpSlider.value = hp;
    }
    
    // panel ) gameOver
    public void ShowGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    // button ) restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
