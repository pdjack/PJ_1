using UnityEngine;

public enum ItemType
{
    Equipment,
    PassiveCard
}

public abstract class ItemData : ScriptableObject
{
    public GameObject icon;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
