using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    public float shootCooldownCountdown, shootCooldown;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    [SerializeField] int currentExp, maxExp;
    public float health, maxHealth;
    [SerializeField] HealthBar healthBar;
    [SerializeField] ExperienceBar expBar;
    public float damage;
    public int levelups, currentLevel;

    [SerializeField] Spawner[] spawns;
    [SerializeField] Text lvltext;



    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        expBar = FindObjectOfType<ExperienceBar>();

    }
    private void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        if(!PauseMenu.paused)
        {
            rotate();
            move();
            shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void shoot()
    {
        if (Input.GetMouseButton(0) && shootCooldownCountdown <= 0f)
        {
            weapon.Fire();
            shootCooldownCountdown = shootCooldown;
        }
        else
        {
            shootCooldownCountdown -= Time.deltaTime;
        }
    }

    private void move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void rotate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void LevelUp()
    {
        levelups--;
        currentLevel++;
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
        foreach (var item in spawns)
        {
            item.SpawnerLevelUp();
        }
        lvltext.text = "Current level: " + currentLevel + ", Level Ups Available: " + levelups;
    }
    public void LevelUpHp()
    {
        maxHealth = (int)Mathf.Round(maxHealth * 1.5f);
        LevelUp();
    }

    public void LevelUpDmg()
    {
        damage++;
        LevelUp();
    }

    public void LevelUpAtkSpd()
    {
        shootCooldown *= 0.9f;
        shootCooldownCountdown = shootCooldown;
        LevelUp();
    }

    public void LevelUpMoveSpd()
    {
        moveSpeed *= 1.2f;
        LevelUp();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }

    public void AddExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= maxExp)
        {
            levelups++;
            health = maxHealth;
            healthBar.UpdateHealthBar(health, maxHealth);
            currentExp = currentExp - maxExp;
            maxExp = (int)Mathf.Round(maxExp * 1.3f);
        }
        expBar?.UpdateExperienceBar(currentExp, maxExp);
        lvltext.text = "Current level: " + currentLevel + ", Level Ups Available: " + levelups;
    }
}
