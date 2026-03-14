using UnityEngine;

public enum StatType { AttackDamage, MaxHpUp, Speed, CriticalRate }

[CreateAssetMenu(fileName = "New Stat Card", menuName = "ScriptableObjects/UpgradeCard/StatCard")]
public class StatUpgradeCardData : UpgradeCardData
{
    [Header("Stat Info")]
    [SerializeField] private StatType _statType;
    [SerializeField] private float _value;

    public override void ApplyEffect(GameObject target)
    {
        if (target == null)
        {
            Debug.LogWarning("ApplyEffect: Target이 null입니다.");
            return;
        }

        PlayerStat stats = target.GetComponent<PlayerStat>();
        if (stats != null)
        {
            switch (_statType)
            {
                case StatType.AttackDamage:
                    stats.AddBonusDamage(_value);
                    break;
                case StatType.MaxHpUp:
                    stats.AddMaxHp(_value);
                    break;
                case StatType.Speed:
                    // TODO: stats.AddSpeed(_value); PlayerStat에 구현 필요
                    break;
                case StatType.CriticalRate:
                    // TODO: stats.AddCriticalRate(_value); PlayerStat에 구현 필요
                    break;
            }
            Debug.Log($"[단순 수치 로직 실행] {target.name}의 {_statType}을(를) {_value}만큼 증가시킵니다.");
        }
        else
        {
            Debug.LogWarning($"ApplyEffect: {target.name}에 PlayerStat 컴포넌트가 없습니다.");
        }
    }
}
