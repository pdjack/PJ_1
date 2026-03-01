using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]private MonsterData monsterData;
    
    // 시험 후 private 바꾸기
    public float _hp;
    public float _damage;
    
    private SpriteRenderer _sr;
    private Color _originalColor;

    private GameObject _player;
    
    [SerializeField]private float nextAttackTime;
    
    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        
        _hp = monsterData.stats.maxHp;
        _damage = monsterData.attack.damage;
        
        _originalColor = _sr.color;
    }

    
    void Update()
    {
        MoveMonster();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Equipment"))
        {
            OnDamaged(other.gameObject);
        }
        
    }

    public bool CanAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + monsterData.attack.attackSpeed;
            return true;
        }
        return false;
    }

    public float GetDamage()
    {
        return _damage;
    }
    
    public void Init(WaveDetail wave)
    {
        _hp = monsterData.stats.maxHp * wave.hpMultiplier;
    }

    void OnDamaged(GameObject equip)
    {
        int equipDamage = equip.GetComponent<Equipment>().GetDamage();
        _hp -= equipDamage;
        
        _sr.color = Color.red;
        Invoke(nameof(ResetColor), 0.1f);
        
        if (_hp <= 0)
        {
            OnDie();
        }
    }
    
    private void ResetColor() => _sr.color = _originalColor;

    void OnDie()
    {
        Destroy(this.gameObject);
    }

    void MoveMonster()
    {
        float distance = Vector2.Distance(_player.transform.position, transform.position);

        if (distance > 1f)
        {
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            float moveSpeed = monsterData.stats.moveSpeed;
            
            transform.Translate(direction * (moveSpeed * Time.deltaTime));
            
            if (direction.x > 0)
            {
                _sr.flipX = false; // 오른쪽을 봄
            }
            else if (direction.x < 0)
            {
                _sr.flipX = true; // 왼쪽을 봄
            }
        }
        
    }
    
    
}
