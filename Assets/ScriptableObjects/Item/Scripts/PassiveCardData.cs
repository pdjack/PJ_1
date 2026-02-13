using UnityEngine;

[CreateAssetMenu(fileName = "New Passive Card", menuName = "ScriptableObjects/Items/PassiveCard")]
public class PassiveCardData : ItemData
{
    public GameObject passiveCardPrefab;
    
    public PassiveType targetStat; // 인스펙터에서 선택 가능
    public float modifier;
    
    void Awake()
    {
        type = ItemType.PassiveCard;
    }
}

public enum PassiveType
{
    MoveSpeed,    // 이동 속도
    DamageAlpha,  // 공격력 퍼센트 증가
    Cooldown,     // 쿨타임 감소
    MaxHealth,    // 최대 체력
    ExpBonus      // 경험치 획득량
}
