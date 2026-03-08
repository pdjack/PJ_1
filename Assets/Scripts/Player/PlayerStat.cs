using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat Instance { get; private set; }

    [Header("HP Settings")]
    //private 으로 바꾸기
    private float maxHp = 100f;
    [SerializeField]private float currentHp;

    [Header("Damage Settings")] 
    [SerializeField]private EquipmentData currentEquipment;
    
    //private 으로 바꾸기
    [SerializeField]private float _damage = 0f;
    [SerializeField]private float _bonusDamage = 0f;

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

    private void Start()
    {
        _damage = currentEquipment.damage;
    }

    public EquipmentData GetCurrentEquip()
    {
        return currentEquipment;
    }
    
    private void SetBonusDamage(float bonus)
    {
        _bonusDamage = bonus;
    }
    
    public void ApplyUpgrade(UpgradeCardData data)
    {
        switch (data.type)
        {
            case UpgradeType.AttackDamage:
                Debug.Log(_bonusDamage += data.value);
                SetBonusDamage(_bonusDamage += data.value);
                //_bonusDamage += data.value;
                break;
        }
    }
    
    public float GetDamage()
    {
        return (_damage + _bonusDamage);
    }

    
}
