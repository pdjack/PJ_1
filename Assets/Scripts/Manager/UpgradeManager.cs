using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyUpgrade(UpgradeCardData data)
    {
        Debug.Log("Applying upgrade");
        if (data == null) return;

        switch (data.type)
        {
            case UpgradeType.AttackDamage:
                PlayerStat.Instance.AddBonusDamage(data.value);
                break;
            case UpgradeType.MaxHpUp:
                PlayerStat.Instance.AddMaxHp(data.value);
                break;
        }
    }
}
