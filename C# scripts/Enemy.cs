using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth;

    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [SerializeField] HealthBar healthBar;
    private Player player;



    int expAmount = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBar>();
        player = FindAnyObjectByType<Player>();
    }
    private void Start()
    {

        health = maxHealth*(1 + player.currentLevel*0.2f);
        moveSpeed *= (1 + player.currentLevel * 0.1f);
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if(target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity=new Vector2(moveDirection.x, moveDirection.y)*moveSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            //ExperienceManager.Instance.AddExperience(expAmount);
            player?.AddExperience(expAmount);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.TakeDamage(1);
            Destroy(gameObject);
        }
    }

}
