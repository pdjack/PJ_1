using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }
    
    [Header("Wave Settings")]
    [SerializeField]WaveData wD;
    [SerializeField] private CardManager _cardManager;

    private int _waveCount; // 몇 웨이브 인지(UI 표시용)
    private int _waveIndex; // 리스트 인덱스
    private WaveDetail _currentWave; // 현재 웨이브
    
    private void Awake()
    {
        // 싱글톤 초기화 로직
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지하고 싶다면 추가
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _waveCount = 1;
        _currentWave = wD.waves[_waveIndex];
    }

    public WaveData GetWaveData()
    {
        return wD;
    }

    public WaveDetail GetCurrentWave()
    {
        return _currentWave;
    }

    // 다음 웨이브가 될 때
    public void NextWave()
    {
        //Wave
        _waveCount++;
        UIManager.Instance.UpdateWaveText(_waveCount);
        
        // 업그레이드 패널 표시 (CardManager를 통해 Push)
        _cardManager.PickAndShow();

        // 다음 웨이브 데이터가 있는지 확인 후 인덱스 증가
        if (_waveIndex + 1 < wD.waves.Count) 
        {
            if (_waveCount >= wD.waves[_waveIndex + 1].waveStep)
            {
                _waveIndex++;
                _currentWave = wD.waves[_waveIndex];
            }
        }
    }
}
