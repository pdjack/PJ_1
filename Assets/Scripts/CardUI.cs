using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _selectButton;

    private UpgradeCardData _cardData;

    private void Awake()
    {
        if (_selectButton != null)
        {
            _selectButton.onClick.AddListener(OnCardClicked);
        }
    }

    public void Setup(UpgradeCardData data)
    {
        _cardData = data;
        
        _cardNameText.text = data.cardName;
        _descriptionText.text = data.description;
        _iconImage.sprite = data.icon;
    }

    private void OnCardClicked()
    {
        // bonus value
        PlayerStat.Instance.ApplyUpgrade(_cardData);
        
        // 패널을 닫고 시간을 재개
        UIManager.Instance.CloseUpgradePanel();
    }
}
