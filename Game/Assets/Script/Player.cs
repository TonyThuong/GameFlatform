using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 velocity;
    private Rigidbody2D r2;
    private Sprite mySprite;
    private SpriteRenderer sr;
    public float speed = 30f, maxspeed = 3, jumpPow = 220f;
    public bool grounded = true, faceright = true, doubleJump = false;
    public Animator anim;
    public GameMaster gm;
    public SoundManager sound;

    [SerializeField] // an ham private ra ngoai
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<GameMaster>();
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        //nhay
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                
                grounded = false;   
                doubleJump = true;    
                r2.AddForce(Vector2.up * jumpPow);
            }

            else
            {
                if(doubleJump)
                {
                    doubleJump = false;
                    r2.velocity = new Vector2 (r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow *0.7f);
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        //cap nhat cho nhan vat di chuyen ngang
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right)*speed*h);

        // gioi han toc do
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2 (maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2 (-maxspeed, r2.velocity.y);

        // xoay doi huong
        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
    }    
        // ham xoay
        public void Flip()
        {
            faceright = !faceright;
            Vector3 Scale;
            Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    
    // An Tien
     private void OnTriggerEnter2D(Collider2D col)   
     {
         if (col.CompareTag("Coin"))
         {
             sound.PlaySound("coins");
             Destroy(col.gameObject);
             gm.points += 1;

         }

         if (col.CompareTag("die"))
         {
             SceneManager.LoadScene("End");
         }
     }
    
}