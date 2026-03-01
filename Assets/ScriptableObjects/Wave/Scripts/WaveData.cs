using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MonsterSpawnInfo // 특정 몬스터와 그 수를 쌍으로 관리
{
    public MonsterData monster;
    public int count;
}

[System.Serializable]
public class WaveDetail
{
    [Header("Wave Info")]
    public string waveName; // 에디터 식별용
    public int waveStep;
    
    [Header("Spawn Settings")]
    public float spawnInterval;
    public List<MonsterSpawnInfo> monsterList; // 어떤 몬스터를 몇 마리 소환할지
    
    [Header("Difficulty Scaling")]
    public float damageMultiplier = 1f; //기본 공격력에 곱해질 수치 배율
    public float hpMultiplier = 1f;
    public float speedMultiplier = 1f;
    
    public int GetTotalCount() 
    {
        int total = 0;
        foreach(var info in monsterList) total += info.count;
        return total;
    }
}

[CreateAssetMenu(fileName = "New Wave Data", menuName = "ScriptableObjects/Monster/WaveData")]
public class WaveData : ScriptableObject
{
    public List<WaveDetail> waves = new List<WaveDetail>();
}