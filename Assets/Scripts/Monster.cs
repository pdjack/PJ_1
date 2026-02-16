using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    private float _hp;
    
    private SpriteRenderer _sr;
    private Color _originalColor;

    private GameObject _player;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _originalColor = _sr.color;
        
        _player = GameObject.FindGameObjectWithTag("Player");
        _hp = monsterData.stats.maxHp;
    }

    
    void Update()
    {
        MoveMonster();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Equipment"))
        {
            OnDamaged(other);
        }
    }
    
    public void Init(WaveDetail wave)
    {
        _hp = monsterData.stats.maxHp * wave.hpMultiplier;
    }

    void OnDamaged(Collider2D other)
    {
        int equipDamage = other.GetComponent<Equipment>().equipmentData.damage;
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
