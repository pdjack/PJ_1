using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    private float _timer;
    private int _monsterCount = 0;
    private float _spawnInterval;

    void Update()
    {
        _timer += Time.deltaTime;
        if (WaveManager.Instance.GetCurrentWave() == null)
        {
            Debug.Log("currentWave is null");
        }
        if (_monsterCount <= WaveManager.Instance.GetCurrentWave().GetTotalCount() && _timer > _spawnInterval)
        {
            SpawnRandomMonster();
            _timer = 0;
        }
    }

// 2. 실제 몬스터를 소환 & 상태 초기화 & 웨이브 체크
    void SpawnRandomMonster()
    {
        // 무작위 선택 및 소환
        int spawnIndex = Random.Range(0, WaveManager.Instance.GetCurrentWave().monsterList.Count);
        if (WaveManager.Instance.GetCurrentWave().monsterList == null)
        {
            Debug.Log("monList is null");
        }
        int randomX = Random.Range(4, 9);
        int randomY = Random.Range(7, 9);
        GameObject monster = Instantiate(WaveManager.Instance.GetCurrentWave().monsterList[spawnIndex].monster.monsterPrefab, new Vector2(randomX, randomY), Quaternion.identity);
        _monsterCount++;
        
        // 몬스터 소환 주기 & 몬스터 스텟 설정
        _spawnInterval = WaveManager.Instance.GetCurrentWave().spawnInterval;
        monster.GetComponent<Monster>().Init(WaveManager.Instance.GetCurrentWave());
        
        // 소환 완료 후 웨이브 체크
        if (_monsterCount >= WaveManager.Instance.GetCurrentWave().GetTotalCount())
        {
            _monsterCount = 0;
            WaveManager.Instance.NextWave();
        }
    }
}
