using UnityEngine;

public enum CardGrade { Common, Rare, Epic, Legendary }

public abstract class UpgradeCardData : ScriptableObject
{
    [Header("Basic Info")]
    public string cardName;        // 카드 이름
    public Sprite icon;            // 카드 아이콘
    public CardGrade grade;        // 카드 등급
    
    [TextArea]
    public string description;     // 설명

    /// <summary>
    /// 카드의 효과를 실행하는 추상 메서드입니다.
    /// </summary>
    /// <param name="target">효과를 적용받을 대상 객체 (일반적으로 Player 객체)</param>
    public abstract void ApplyEffect(GameObject target);
}
