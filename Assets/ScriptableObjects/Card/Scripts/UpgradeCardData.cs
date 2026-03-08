using UnityEngine;

public enum UpgradeType { AttackDamage, EquipCount }
public enum CardGrade { Common, Rare, Epic, Legendary }

[CreateAssetMenu(fileName = "New Card Data", menuName = "ScriptableObjects/UpgradeCard/CardData")]
public class UpgradeCardData : ScriptableObject
{
    public string cardName;        // 카드 이름
    public Sprite icon;            // 카드 아이콘
    public CardGrade grade;        // 카드 등급
    public float value;            // 증가할 수치
    public UpgradeType type;       // 강화 종류 (Enum)
    [TextArea]
    public string description;     // 설명
}
