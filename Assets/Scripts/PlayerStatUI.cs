using UnityEngine;
using TMPro;

public class PlayerStatUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject statPanel;
    [SerializeField] private TMP_Text weaponNameText;
    [SerializeField] private TMP_Text baseDamageText;
    [SerializeField] private TMP_Text bonusDamageText;

    private void Start()
    {
        // 초기에는 패널을 닫아둠
        if (statPanel != null)
        {
            statPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 패널을 열고 능력치를 갱신합니다. (보통 '?' 버튼에 연결)
    /// </summary>
    public void Open()
    {
        if (statPanel != null)
        {
            statPanel.SetActive(true);
            UpdateStats();
        }
    }

    /// <summary>
    /// 패널을 닫습니다. (보통 'X' 버튼에 연결)
    /// </summary>
    public void Close()
    {
        if (statPanel != null)
        {
            statPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 현재 PlayerStat 데이터를 읽어와 UI를 업데이트합니다.
    /// </summary>
    public void UpdateStats()
    {
        if (PlayerStat.Instance == null) return;

        var equip = PlayerStat.Instance.GetCurrentEquip();
        
        // 무기 이름 표시 (ScriptableObject의 name 사용, 없을 시 "None")
        if (weaponNameText != null)
        {
            weaponNameText.text = equip != null ? equip.name : "None";
        }

        // 기본 공격력 표시
        if (baseDamageText != null)
        {
            baseDamageText.text =  PlayerStat.Instance.BaseDamage.ToString("F0");
        }

        // 보너스 공격력 표시
        if (bonusDamageText != null)
        {
            bonusDamageText.text = "+" + PlayerStat.Instance.BonusDamage.ToString("F0");
        }
    }
}
