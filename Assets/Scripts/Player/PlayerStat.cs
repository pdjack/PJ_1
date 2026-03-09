using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat Instance { get; private set; }

    // private 고치기
    [Header("HP Settings")]
    [SerializeField] private float _maxHp = 100f;
    [SerializeField] private float _bonusHp = 0f;
    [SerializeField] private float _hp;

    public float MaxHp => _maxHp;
    public float Hp => _hp;

    [Header("Damage Settings")] 
    [SerializeField]private EquipmentData currentEquipment;
    
    [SerializeField]private float _damage = 0f;
    [SerializeField]private float _bonusDamage = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // 초기 체력 설정
            _hp = _maxHp;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetHp(float value)
    {
        _hp = Mathf.Clamp(value, 0f, MaxHp);
    }

    public void AddMaxHp(float amount)
    {
        _maxHp += amount;
        _hp += amount;
        Debug.Log($"[PlayerStat] MaxHP Up: +{amount} (Current MaxHP: {_maxHp})");
    }

    private void Start()
    {
        _damage = currentEquipment.damage;
    }

    public EquipmentData GetCurrentEquip()
    {
        return currentEquipment;
    }
    
    public void AddBonusDamage(float amount)
    {
        _bonusDamage += amount;
        Debug.Log($"[PlayerStat] Bonus Damage Up: +{amount} (Total Bonus: {_bonusDamage})");
    }
    
    public float GetDamage()
    {
        return (_damage + _bonusDamage);
    }

    
}
