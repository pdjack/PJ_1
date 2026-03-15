using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private EquipmentData _equipData;
    private GameObject _equipment;
    private float _bonusDamage;

    [Header("Dizzy Debuff Settings")]
    public float _accumulatedRotation = 0f;
    public float _lastAngle = 0f;
    public bool _isDizzy = false;

    private const float ROTATION_THRESHOLD = 3600f;
    private const float DIZZY_DURATION = 5f;

    void Start()
    {
        _equipData = PlayerStat.Instance.GetCurrentEquip();
        _equipment = Instantiate(_equipData.equipmentPrefab, transform.position, Quaternion.identity);
        _equipment.transform.parent = this.transform;

        // 초기 각도 설정
        _lastAngle = GetMouseAngle();
    }

    void Update()
    {
        // 어지러움 상태인 경우 회전 및 공격 불가
        if (_isDizzy) return;

        RotateWeaponToMouse();
        TrackRotation();
    }

    void RotateWeaponToMouse()
    {
        float angle = GetMouseAngle();
        _equipment.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float GetMouseAngle()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        Vector2 direction = (Vector2)worldPos - (Vector2)_equipment.transform.position;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    void TrackRotation()
    {
        float currentAngle = GetMouseAngle();
        
        // 프레임 간 회전 변화량의 절대값을 누적
        float delta = Mathf.Abs(Mathf.DeltaAngle(_lastAngle, currentAngle));
        _accumulatedRotation += delta;
        _lastAngle = currentAngle;

        // 임계값(3600도) 도달 시 디버프 발생
        if (_accumulatedRotation >= ROTATION_THRESHOLD)
        {
            StartCoroutine(DizzyRoutine());
        }
    }

    IEnumerator DizzyRoutine()
    {
        _isDizzy = true;
        _accumulatedRotation = 0f;

        // 5초간 대기
        yield return new WaitForSeconds(DIZZY_DURATION);

        _isDizzy = false;
        
        // 디버프 해제 후 복귀 시 각도 튀는 현상 방지를 위해 현재 각도 재설정
        _lastAngle = GetMouseAngle();
    }
}
