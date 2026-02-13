using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data", menuName = "Monster/Attack Data")]
public class MonAttackData : ScriptableObject
{
    public int damage;
    public float attackSpeed;
    public float range;
}
