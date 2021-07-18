using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum AttackStyle
{
    Bite,
    Shoot,
    BossBite
};

public enum BehaviourStyle
{
    Follow,
    Die,
    Attack,
    Search
};



public class EnemyStateManager : MonoBehaviour
{

   
  
    public AIDestinationSetter destination;
    public bool gotHit = false;

    public float Health;

    GameObject player;
    public AttackStyle AttackStyle;
    public BehaviourStyle State = BehaviourStyle.Search;
    public float range;
    public float attackRange;
    public float bulletSpeed;

    public float Distance;
    public float wander;
    public float timer = 5f;

    public float waitTime;
    private bool waitTimeCheck = false;
    public GameObject bulletPrefab;
    public bool Follow;


    public Vector3 oldP, newP;
    public bool proof = false;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destination = GetComponent<AIDestinationSetter>();
        oldP = transform.position;

    }

    void FixedUpdate()
    {

        if (Health <= 0) {
            Death();
        }

        switch (State)
        {
            case (BehaviourStyle.Follow):
                Follow = true;
                if (!gotHit)
                {
                    destination.ai.destination = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                }
                else {
                    StartCoroutine(GotHit());
                    gotHit = false;
                }
                break;
            case (BehaviourStyle.Die):
                Destroy(this);
                break;
            case (BehaviourStyle.Attack):
                Attack();
                break;
            case (BehaviourStyle.Search):
                Follow = false;                
                destination.ai.destination = new Vector3(transform.position.x + wander, transform.position.y + wander, transform.position.z);
                break;
        }

            if (!IsPlayerInRange(range)) {
                State = BehaviourStyle.Search;
                wander = Random.Range(-10f, 10f);
            }
            else if(Vector3.Distance(transform.position, player.transform.position) > attackRange)
            {
                State = BehaviourStyle.Follow;
            }
            else
            {
                State = BehaviourStyle.Attack;
            }
        
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }   

    void Attack()
    {
        if (!waitTimeCheck)
        {
            switch (AttackStyle)
            {
                case (AttackStyle.Shoot):
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<BulletManager>().belongsToEnemy = true;
                    bullet.GetComponent<BulletManager>().player = player.transform.position;
                    bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                    StartCoroutine(wait());
                    break;

                case (AttackStyle.BossBite):
                    GameManager.DealDamage(2);
                    StartCoroutine(wait());
                    break;

                case (AttackStyle.Bite):
                    GameManager.DealDamage(1);
                    StartCoroutine(wait());
                    break;
            }
        }
    }

   

    

    private IEnumerator GotHit()
    {
        Color c = GetComponent<Renderer>().material.color;
        float red = c.r, green = c.g, blue = c.b, alpha = c.a;
        
        for (int i = 0; i < 3; i++)
        {
            c.g = 0;
            c.b = 0;
            for (float j = 1f; j >= 0; j -= 0.1f)
            {                
                c.a = j;
                GetComponent<Renderer>().material.color = c;
            }
            c.g = 1;
            c.b = 1;
            for (float j = 0f; j <= 1.2; j += 0.1f)
            {                
                c.a = j;
                GetComponent<Renderer>().material.color = c;
            }
        }
        c.r = red;
        c.g = green;
        c.b = blue;
        c.a = alpha;
        yield return null;
    }


    private IEnumerator wait()
    {
        waitTimeCheck = true;
        yield return new WaitForSeconds(waitTime);
        waitTimeCheck = false;
    }

    public void Death()
    {
        ZoneManager.instance.StartCoroutine(ZoneManager.instance.RoomCoroutine());
        Destroy(gameObject);
    }

   
}
