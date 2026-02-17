using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField]private float _hp;
    
    private SpriteRenderer _sr;
    private Color _originalColor;

    private GameObject _player;
    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _originalColor = _sr.color;
        
        _player = GameObject.FindGameObjectWithTag("Player");
        _hp = monsterData.stats.maxHp;
        Debug.Log("monster Awake");
    }

    
    void Update()
    {
        MoveMonster();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnDamaged(other.gameObject);
    }
    
    public void Init(WaveDetail wave)
    {
        _hp = monsterData.stats.maxHp * wave.hpMultiplier;
    }

    void OnDamaged(GameObject equip)
    {
        int equipDamage = equip.GetComponent<Equipment>().equipmentData.damage;
        //Debug.Log("_hp" + _hp);
        _hp -= equipDamage;
        //Debug.Log("_hp" + _hp);
        
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
