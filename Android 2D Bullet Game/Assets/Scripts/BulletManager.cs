using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public ParticleSystem fire;
    public Vector2 player;
    private Vector2 lastPos, curPos;
    public float timeDestroy;
    public bool belongsToEnemy = false;
    public bool boss = false;

    void Start()
    {
        fire.Play();
        float size;
        if (belongsToEnemy == true)
        {
            size = 1;
        }
        else {
            size = GameManager.BulletSize;
        }

        transform.localScale = new Vector2(size, size);

        StartCoroutine(WaitForDestruction());
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Flamable" && !belongsToEnemy)
        {
            //flame logic
            Destroy(gameObject);
        }

        if (col.tag == "Flamable" && belongsToEnemy)
        {
            Destroy(gameObject);
        }


        if (col.tag == "Player" && belongsToEnemy)
        {
            GameManager.DealDamage(1);
            col.gameObject.GetComponent<PlayerManager>().StartCoroutine("GotHit");
            Destroy(gameObject);
        }

        if (col.tag == "Enemy" && !belongsToEnemy)
        {
            col.gameObject.GetComponent<EnemyStateManager>().Health -= 1;
            col.gameObject.GetComponent<EnemyStateManager>().gotHit = true;
            Destroy(gameObject);
        }
    }


    void FixedUpdate()
    {
        fire.transform.position = transform.position;
        if (belongsToEnemy)
        {
            curPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player, 5f * Time.deltaTime);

            if (curPos == lastPos && !boss)
            {
                Destroy(gameObject);
            }
            lastPos = curPos;
        }
    }

    IEnumerator WaitForDestruction()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
    }

}
