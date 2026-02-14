using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "ScriptableObjects/Monster/WaveData")]
public class WaveData : ScriptableObject
{
    public List <WaveDetail> waveData = new List<WaveDetail>();
}

[System.Serializable]
public class WaveDetail
{
    public List<MonsterData> monsters = new List<MonsterData>(); // 소환할 몬스터
    public int waveStep;        // 몇 번째 웨이브인지 (5, 10 등)
    public float spawnInterval; // 소환 간격
    public int totalMonsters;   // 총 몬스터 수
}
