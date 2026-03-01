using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }
    
    [Header("Wave Settings")]
    [SerializeField]private List<WaveData> waves;    // 미리 만들어둔 웨이브 데이터 리스트
    
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
        
    }
}
