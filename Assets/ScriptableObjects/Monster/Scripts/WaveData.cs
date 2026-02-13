using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "ScriptableObjects/Monster/WaveData")]
public class WaveData : ScriptableObject
{
    public List<MonsterData> dayMonsters = new List<MonsterData>();
}
