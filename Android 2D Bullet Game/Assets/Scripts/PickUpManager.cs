using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public Sprite itemImage;
    public string name;
    public string description;
}


public class PickUpManager: MonoBehaviour
{

    public Item loadInformation;
    public int health;
    public float speed;
    public float attack;
    public float size;



    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = loadInformation.itemImage;
        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            GameManager.UpdateFireRate(attack);
            GameManager.UpdateSizeBullet(size);
            GameManager.Heal(health);
            GameManager.UpdateMovementSpeed(speed);
            Destroy(gameObject);
        }

    }

}
