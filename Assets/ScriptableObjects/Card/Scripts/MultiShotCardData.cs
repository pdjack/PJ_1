using UnityEngine;

[CreateAssetMenu(fileName = "New Special Card", menuName = "ScriptableObjects/UpgradeCard/SpecialCard/MultiShot")]
public class MultiShotCardData : UpgradeCardData
{
    [Header("Special Effect Info")]
    [SerializeField] private int _extraProjectiles = 2;
    [SerializeField] private float _damageMultiplier = 0.8f;

    public override void ApplyEffect(GameObject target)
    {
        if (target == null)
        {
            Debug.LogWarning("ApplyEffect: Target이 null입니다.");
            return;
        }

        // 특정 컴포넌트를 가져와 복잡한 로직을 적용합니다. 
        // Example:
        // PlayerAttack controller = target.GetComponent<PlayerAttack>();
        // if (controller != null)
        // {
        //     controller.EnableMultiShot(_extraProjectiles, _damageMultiplier);
        // }

        Debug.Log($"[특수 로직 실행] {target.name}에 멀티샷 발동 (발사체 +{_extraProjectiles}, 데미지 배분: {_damageMultiplier}).");
    }
}
