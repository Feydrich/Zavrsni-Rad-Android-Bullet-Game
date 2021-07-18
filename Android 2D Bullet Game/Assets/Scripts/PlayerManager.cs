using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



[RequireComponent(typeof(Light))]
public class PlayerManager : MonoBehaviour
{    
    public float speed;
    public Rigidbody2D rigidbody;
    public float horizontal, vertical, shootHor, shootVert;
    public GameObject light;


    public Joystick joystick1;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;

    private float tracker;

    public ParticleSystem dust;
    public float timer;




    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;        
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(x * bulletSpeed, y * bulletSpeed, 0);
       
    }

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        tracker = GameManager.Health;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        light.transform.position = this.transform.position;
        

        fireDelay = GameManager.FireRate;
        speed = GameManager.MoveSpeed;

        horizontal = joystick1.Horizontal;
        vertical = joystick1.Vertical;

        shootHor = CrossPlatformInputManager.GetAxis("Horizontal");
        shootVert = CrossPlatformInputManager.GetAxis("Vertical");

        if (tracker != GameManager.Health && tracker > GameManager.Health)
        {
            tracker = GameManager.Health;
            StartCoroutine("GotHit");
        }

        if (tracker != GameManager.Health && tracker < GameManager.Health)
        {
            tracker = GameManager.Health;
        }

        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, shootVert);
            lastFire = Time.time;
        }

        rigidbody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
        if (rigidbody.velocity.magnitude <= 0) {
            CreateDust();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Fog") {
            Debug.LogWarning("Yahoo!");
            Destroy(col.gameObject);
        }
    }

    public IEnumerator GotHit()
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

    public void CreateDust() {
        dust.Play();
    }

}

