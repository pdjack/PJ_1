using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public WaveData monsters;
    private int _currentSpawnIndex = 0;
    private float _timer;
    private GameObject _player;
    private float spawnInterval = 2f;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
        if (_currentSpawnIndex < monsters.dayMonsters.Count && _timer > spawnInterval)
        {
            SpawnMonster(monsters.dayMonsters[_currentSpawnIndex].monsterPrefab);

            spawnInterval = monsters.dayMonsters[_currentSpawnIndex].spawnInterval;
            _currentSpawnIndex = Random.Range(0, monsters.dayMonsters.Count);
            _timer = 0;
        }
    }

    private void SpawnMonster(GameObject monster)
    {
        int randomX = Random.Range(4, 9);
        int randomY = Random.Range(7, 9);
        Instantiate(monster, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
