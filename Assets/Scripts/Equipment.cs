using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]private EquipmentData equipmentData;

    public int GetDamage()
    {
        return equipmentData.damage;
    }
}
