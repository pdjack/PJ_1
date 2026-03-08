using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private EquipmentData _equipData;
    private GameObject _equipment;
    private float _bonusDamage;

    void Start()
    {
        _equipData = PlayerStat.Instance.GetCurrentEquip();
        _equipment = Instantiate(_equipData.equipmentPrefab, transform.position, Quaternion.identity);
        _equipment.transform.parent = this.transform;
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
    
}
