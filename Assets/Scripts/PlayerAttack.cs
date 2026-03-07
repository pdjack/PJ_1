using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private EquipmentData equipment;
    private GameObject _equipment;
    private float _bonusDamage; // 카드 업그레이드로 인한 추가 공격력

    void Start()
    {
        _equipment = Instantiate(equipment.equipmentPrefab, transform.position, Quaternion.identity);
        _equipment.transform.parent = this.transform;
        
        // 초기 보너스 데미지 설정
        UpdateEquipmentBonus();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeaponToMouse();
    }

    void RotateWeaponToMouse()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        
        Vector2 direction = worldPos - _equipment.transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _equipment.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    /// <summary>
    /// 카드 업그레이드 효과를 적용합니다.
    /// </summary>
    public void ApplyUpgrade(UpgradeCardData data)
    {
        switch (data.type)
        {
            case UpgradeType.AttackDamage:
                _bonusDamage += data.value;
                UpdateEquipmentBonus();
                Debug.Log($"공격력 증가! 현재 보너스: {_bonusDamage}");
                break;
            case UpgradeType.EquipCount:
                // 추가 장비 관련 로직 (필요 시 구현)
                break;
        }
    }

    private void UpdateEquipmentBonus()
    {
        if (_equipment != null)
        {
            Equipment equipScript = _equipment.GetComponent<Equipment>();
            if (equipScript != null)
            {
                equipScript.SetBonusDamage(_bonusDamage);
            }
        }
    }

    public float GetTotalDamage()
    {
        return equipment.damage + _bonusDamage;
    }
}
