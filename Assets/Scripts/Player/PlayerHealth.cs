using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void Start()
    {
        
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
        float currentHp = PlayerStat.Instance.Hp;
        float maxHp = PlayerStat.Instance.MaxHp;
        
        currentHp -= damage;
        PlayerStat.Instance.SetHp(currentHp);
        
        UIManager.Instance.ShowPlayerHpSlider(currentHp / maxHp);

        if (currentHp <= 0)
        {
            OnDie();
        }
    }

    void OnDie()
    {
        UIManager.Instance.ShowGameOverPanel();
    }
}
