using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private GameObject _player;
    public WaveData wD;
    
    private int _spawnIndex = 0;
    private float _timer;
    
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
        
        //몬스터의 개수 < waveData[_waveIndex]의 총 몬스터 수 && 시간 > 스폰 간격
        if (_monsterCount < wD.waveData[_waveIndex].totalMonsters && _timer > _spawnInterval)
        {
            //_spawnIndex = 랜덤(0, waveData[_waveIndex]의 몬스터 리스트의 개수)
            _spawnIndex = Random.Range(0, wD.waveData[_waveIndex].monsters.Count);
            // (waveData[_waveIndex]의 몬스터 리스트)[_spawnIndex]
            SpawnMonster(wD.waveData[_waveIndex].monsters[_spawnIndex].monsterPrefab);

            // _spawnInterval = waveData[_waveIndex]의 스폰 간격
            _spawnInterval = wD.waveData[_waveIndex].spawnInterval;
            
            //타이버 초기화
            _timer = 0;
            //몬스터 개수 += 1
            _monsterCount++;
            
            // _monsterCount >= waveData[_waveCount]의 총 몬스터 수
            if (_monsterCount >= wD.waveData[_waveIndex].totalMonsters)
            {
                // _waveCount +=1
                _waveCount++;
                _monsterCount = 0;
                
                if (_waveCount >= wD.waveData[_waveIndex + 1].waveStep)
                {
                    _waveIndex++;
                }
            }
        }
    }

    private void On()
    {
        
    }

    private void SpawnMonster(GameObject monster)
    {
        int randomX = Random.Range(4, 9);
        int randomY = Random.Range(7, 9);
        Instantiate(monster, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
