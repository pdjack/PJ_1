using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float _maxHp = 100f;
    private float _hp;
    
    void Start()
    {
        _hp = _maxHp;
    }
    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            
            // 몬스터 개별의 쿨타임이 지났는지 확인
            if (monster != null && monster.CanAttack())
            {
                OnDamaged(monster.GetDamage());
            }
        }
    }

    void OnDamaged(float damage)
    {
        _hp -= damage;
        UIManager.Instance.ShowPlayerHpSlider(_hp * 0.01f);

        if (_hp <= 0)
        {
            OnDie();
        }
    }

    void OnDie()
    {
        Debug.Log("죽음");
    }
}
