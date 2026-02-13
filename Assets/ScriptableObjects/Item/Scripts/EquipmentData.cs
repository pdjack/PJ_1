using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "ScriptableObjects/Items/Equipment")]
public class EquipmentData : ItemData
{
    public GameObject equipmentPrefab;
    public int damage;
    public int defense;
    
    void Awake()
    {
        type = ItemType.Equipment;
    }
}
