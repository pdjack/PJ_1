using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI _waveText;
    
    [Header("UI Slider")]
    [SerializeField] private Slider _hpSlider;
    
    [Header("UI Panel")]
    [SerializeField] private GameObject _gameOverPanel;

    [Header("Card Settings")]
    [SerializeField] private CardUI _cardUIUp;
    [SerializeField] private CardUI _cardUIDown;

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
        //text
        _waveText.text = "Wave." + 1;
        //slider
        ShowPlayerHpSlider(1);
        //panel
        _gameOverPanel.SetActive(false);
        _cardUIUp.gameObject.SetActive(false);
        _cardUIDown.gameObject.SetActive(false);

    }

    //text
    
    // text ) waveCount
    public void UpdateWaveText(int waveCount)
    {
        _waveText.text = "Wave." + waveCount.ToString();
    }
    
    //slider

    // slider ) player hp
    public void ShowPlayerHpSlider(float hp)
    {
        _hpSlider.value = hp;
    }
    
    //panel
    
    // panel ) gameOver
    public void ShowGameOverPanel()
    {
        if (_gameOverPanel != null)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // panel ) upgrade
    public void ShowUpgradePanel(List<UpgradeCardData> selectedCards)
    {
        if (selectedCards == null) return;

        // 카드 UI 셋업
        if (selectedCards.Count >= 1 && _cardUIUp != null)
        {
            _cardUIUp.Setup(selectedCards[0]);
            _cardUIUp.gameObject.SetActive(true);
        }
        
        if (selectedCards.Count >= 2 && _cardUIDown != null)
        {
            _cardUIDown.Setup(selectedCards[1]);
            _cardUIDown.gameObject.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void CloseUpgradePanel()
    {
        if (_cardUIUp != null) _cardUIUp.gameObject.SetActive(false);
        if (_cardUIDown != null) _cardUIDown.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    //button
    
    // button ) restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
