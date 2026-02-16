using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private GameObject _player;
    public WaveData wD;
    
    private float _timer;
    private int _spawnIndex = 0;
    
    private float _spawnInterval;
    private int _monsterCount = 0;
    
    private int _waveCount;
    private int _waveIndex;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _waveCount = 1;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (CanSpawnMonster())
        {
            SpawnRandomMonster();
        }
    }
    
// 1. 몬스터 소환 가능 여부 판단
    bool CanSpawnMonster()
    {
        var currentWave = wD.waves[_waveIndex];
        return _monsterCount <= currentWave.GetTotalCount() && _timer > _spawnInterval;
    }

// 2. 실제 몬스터를 소환 & 상태 초기화 & 웨이브 체크
    void SpawnRandomMonster()
    {
        var currentWave = wD.waves[_waveIndex];
    
        // 무작위 선택 및 소환
        _spawnIndex = Random.Range(0, currentWave.monsterList.Count);
        SpawnMonster(currentWave.monsterList[_spawnIndex].monster.monsterPrefab);

        // 상태 초기화
        _spawnInterval = currentWave.spawnInterval;
        _timer = 0;
        _monsterCount++;

        // 소환 완료 후 웨이브 체크
        if (_monsterCount >= currentWave.GetTotalCount())
        {
            HandleWaveTransition();
        }
    }

// 3. 웨이브++ & 몬스터 스텟 관리
    void HandleWaveTransition()
    {
        _waveCount++;
        UIManager.Instance.UpdateWaveText(_waveCount);
        _monsterCount = 0;

        var monster = wD.waves[_waveIndex].monsterList[_spawnIndex].monster.monsterPrefab.GetComponent<Monster>();
        monster.Init(wD.waves[_waveIndex]);

        // 다음 웨이브 데이터가 있는지 확인 후 인덱스 증가
        if (_waveIndex + 1 < wD.waves.Count) 
        {
            if (_waveCount >= wD.waves[_waveIndex + 1].waveStep)
            {
                _waveIndex++;
            }
        }
    }

    private void SpawnMonster(GameObject monster)
    {
        int randomX = Random.Range(4, 9);
        int randomY = Random.Range(7, 9);
        Instantiate(monster, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
