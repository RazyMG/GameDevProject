using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dieTime = 3f;
    Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }
    private void Update()
    {
        projectileDie();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(player.damage);
        }
        Destroy(gameObject);
    }

    public void projectileDie()
    {
        if (dieTime >= 0f)
        {
            dieTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
