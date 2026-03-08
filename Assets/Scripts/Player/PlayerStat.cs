using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat Instance { get; private set; }

    [Header("HP Settings")]
    public float maxHp = 100f;
    public float currentHp;

    [Header("Damage Settings")]
    public float baseDamage = 10f;
    public float bonusDamage = 0f;

    public float TotalDamage => baseDamage + bonusDamage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // 초기 체력 설정
            currentHp = maxHp;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
