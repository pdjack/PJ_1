using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data", menuName = "Monster/MainData")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public float spawnInterval;
    public GameObject monsterPrefab;
    
    public MonAttackData attack; // 공격 데이터 참조
    public MonStatData stats;    // 방어/능력치 데이터 참조
    
    [TextArea(15, 20)]
    public string description;
}
