using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Monster/WaveData")]
public class WaveData : ScriptableObject
{
    public List<GameObject> dayMonsters = new List<GameObject>();
}
