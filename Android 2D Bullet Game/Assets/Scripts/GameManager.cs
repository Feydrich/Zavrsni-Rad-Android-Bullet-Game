using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum dungeonType{
    Forest,
    Forest2,
    Forest3,
    Beach,
    Beach2,
    Beach3,
    Tundra,
    Snow,
    Snow2
}

public class GameManager : MonoBehaviour
{
    public static dungeonType type = dungeonType.Forest;
    public static GameManager instance;
    private static float fireRate = 0.5f, bulletSize = 5f, moveSpeed = 8f;
    private static int maxHealth = 8, health = 8;
    private float healthChecker;
   

    public Image[] heartContainer, heartPiece;
    public Sprite fullHeart, halfHeart, emptyHeart;

    private float timer = 0;

    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }

    public GameObject levelManager;
    void Awake()
    {
        healthCanvasUpdater();
        healthChecker = health;
        
    }



    void FixedUpdate()
    {
        if (healthChecker != health) {
            healthChecker = health;
            healthCanvasUpdater();
        }

        if (health <= 0) {
            SceneManager.LoadScene("GameOver");
            health = maxHealth;
        }
        
    }

    public static void DealDamage(int damage) {
        health -= damage;
    }


    public static void Heal(int healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }
    public static void UpdateMovementSpeed(float speed)
    {
        moveSpeed += speed;
    }
    public static void UpdateFireRate(float rate)
    {
        fireRate -= rate;
    }
    public static void UpdateSizeBullet(float size)
    {
        bulletSize += size;
    }

    public void healthCanvasUpdater() {
        for (int i = 0; i < heartContainer.Length; i++)
        {

            if (i < maxHealth / 2)
            {
                heartContainer[i].enabled = true;
            }
            else
            {
                heartContainer[i].enabled = false;
            }
        }
        for (int i = 0; i < heartPiece.Length; i++)
        {



            if (i < maxHealth)
            {
                heartPiece[i].enabled = true;
            }
            else
            {
                heartPiece[i].enabled = false;
            }

            if (i < health)
            {
                heartPiece[i].enabled = true;
            }
            else
            {
                heartPiece[i].enabled = false;
            }
        }
    }

    public static string DungeonName() {
        if (type == dungeonType.Forest)
        {
            return "Forest";
        }

        if (type == dungeonType.Forest2) {
            return "Forest2";
        }

        if (type == dungeonType.Forest3)
        {
            return "Forest3";
        }

        if (type == dungeonType.Beach) {
            return "Beach";
        }

        if (type == dungeonType.Beach2)
        {
            return "Beach2";
        }

        if (type == dungeonType.Beach3)
        {
            return "Beach3";
        }

        if (type == dungeonType.Snow)
        {
            return "Snow";
        }

        if (type == dungeonType.Snow2)
        {
            return "Snow2";
        }

        if (type == dungeonType.Tundra)
        {
            return "Tundra";
        }

        else
        {
            return "Forest";
        }
    }

}
