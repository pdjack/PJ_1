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
        if (data == null) return;

        if (PlayerStat.Instance != null)
        {
            // OCP를 준수하여, 각 카드가 자신의 로직을 실행하도록 위임합니다.
            data.ApplyEffect(PlayerStat.Instance.gameObject);
        }
        else
        {
            Debug.LogWarning("ApplyUpgrade: PlayerStat.Instance가 존재하지 않습니다.");
        }
    }
}
