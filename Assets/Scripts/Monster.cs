using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    SpriteRenderer spriteRenderer;

    private GameObject _player;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        MoveMonster();
    }

    void MoveMonster()
    {
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        float moveSpeed = monsterData.stats.moveSpeed;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽을 봄
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽을 봄
        }
    }
}
