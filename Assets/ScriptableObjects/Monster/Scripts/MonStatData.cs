using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Data", menuName = "Monster/Stat Data")]
public class MonStatData : ScriptableObject
{
    public int maxHp;
    public int defense;
    public float moveSpeed;
}
