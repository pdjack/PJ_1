using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]private EquipmentData equipmentData;
    private float _bonusDamage;

    public void SetBonusDamage(float bonus)
    {
        _bonusDamage = bonus;
    }

    public float GetDamage()
    {
        return equipmentData.damage + _bonusDamage;
    }
}
