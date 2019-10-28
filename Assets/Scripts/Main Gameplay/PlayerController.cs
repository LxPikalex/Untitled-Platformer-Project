using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D c2D;

    public bool hasKey;
    private bool pause = false;

    public int deathCount;

    public int currentCoins = 0;
    public int healthPoint = 1;

    public float playerSpeed = 6f;
    public float jumpPower = 100f;

    public GameObject bullet;

    public short mainBaseFireRate;
    public short baseFireRare;
    private short fireRate;


    // Start is called before the first frame update
    void Start()
    {
        c2D = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        fireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #region Player Movement

        float h = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            h = -playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            h = playerSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && 
            Physics2D.BoxCast(c2D.bounds.center, c2D.bounds.size, 0, Vector2.down, 0.05f, 1 << 8))
        {
            rb.AddForce(new Vector2(0, jumpPower));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            float newScale = pause ? 0 : 1; 
            Time.timeScale = newScale; //Switch between true and false and set to 1 and 0 accordingly! thanks Massimo

        }

        Vector2 v = rb.velocity;
        v.x = h*Time.deltaTime;
        rb.velocity = v;
        #endregion

        #region Shooting
        if (fireRate == 0)
        {
            //Holding W will allow shooting bullet2 at a specific rate. 
            if (Input.GetKeyDown(KeyCode.W))
            {
                Vector2 newPos = new Vector2(transform.position.x + 1, transform.position.y);
                Instantiate(bullet, newPos, transform.rotation);
                fireRate = mainBaseFireRate;
            }
        }
        else
            --fireRate;
        #endregion

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            currentCoins++;
        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            hasKey = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            deathCount++;
            transform.position = new Vector3(0, 0, 0);
        }

    }

}
