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

    /// <summary>
    /// 전달받은 카드 데이터로 UI를 업데이트합니다.
    /// </summary>
    public void Setup(UpgradeCardData data)
    {
        _cardData = data;
        
        _cardNameText.text = data.cardName;
        _descriptionText.text = data.description;
        _iconImage.sprite = data.icon;
    }

    private void OnCardClicked()
    {
        // 플레이어의 PlayerAttack 컴포넌트를 찾아 업그레이드 적용
        PlayerAttack playerAttack = FindFirstObjectByType<PlayerAttack>();
        if (playerAttack != null)
        {
            playerAttack.ApplyUpgrade(_cardData);
        }

        // 패널을 닫고 시간을 재개
        UIManager.Instance.CloseUpgradePanel();
    }
}
