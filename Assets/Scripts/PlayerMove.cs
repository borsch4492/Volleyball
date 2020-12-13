using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D rb;
    private bool isAndroid = true;

    public bool autoJump = true;
    public float speed;
    public float thrust;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public GameManagment gm;
    public Joystick playerJoystick;
    public bool isBot;
    public GameObject ball;
    public float difC;
    public float minDifC;
    public float maxDifC;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm.isAndroid = isAndroid;
        StartCoroutine(randDifC(minDifC, maxDifC));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //moveX = Input.GetAxis("Horizontal");
        if (!isBot)
        {
            if (!isAndroid || playerJoystick.Horizontal == 0f)
            {
                if (Input.GetKey(left))
                {
                    move(-1f);
                }
                else if (Input.GetKey(right))
                {
                    move(1f);
                }
                else
                {
                    move(0f);
                }
                if (Input.GetKeyDown(jump))
                {
                    pjump();
                }
            }
            else
            {
                move(playerJoystick.Horizontal);
            }
        }
        else
        {
            float dif = transform.position.x - ball.transform.position.x;
            dif = dif + difC;
            if (dif < 0)
            {
                move(1f);
            }
            else
            {
                move(-1f);
            }
        }
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball" && autoJump)
        {
            pjump();
        }
    }

    public void pjump()
    {
        rb.AddForce(Vector2.up * thrust);
    }

    public void move(float side)
    {
        moveX = side;
    }

    IEnumerator randDifC(float min, float max)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 5f));
            difC = Random.Range(min, max);
            // difC = 0 - difC;
        }
    }
}
