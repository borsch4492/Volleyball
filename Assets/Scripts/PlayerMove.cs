using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D rb;
    //private bool isAndroid = true;

    public bool autoJump = true;
    public float speed;
    public float thrust;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public Joystick playerJoystick;
    public bool isBot;
    public bool isRaycast;
    public bool isLeft;
    public GameObject ball;
    public float difC;
    public float minDifC;
    public float maxDifC;
    public RaycastHit2D hitInfo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //gm.isAndroid = isAndroid;
        if (isBot)
        {
            StartCoroutine(randDifC(minDifC, maxDifC));
            if(Random.Range(0, 2) == 1)
            {
                isRaycast = true;
            }
            else
            {
                isRaycast = false;
            }
        }
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
            if (playerJoystick.Horizontal == 0f)
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
            hitInfo = Physics2D.Raycast(transform.position + new Vector3(difC, 1), Vector2.up);
            //Debug.DrawRay(transform.position + new Vector3(0, 1), transform.TransformDirection(Vector2.up) * hitInfo.distance, Color.green);
            //print(hitInfo.collider.name);
            if (hitInfo.collider.name != "ball" || !isRaycast)
            {
                float dif = transform.position.x - ball.transform.position.x;
                dif = dif + difC;
                if (!isLeft)
                {
                    if (ball.transform.position.x > 0.5f)
                    {
                        if (dif < 0)
                        {
                            move(1f);
                        }
                        else if (dif > 0)
                        {
                            move(-1f);
                        }
                        else
                        {
                            move(0);
                        }
                    }
                    else
                    {
                        move(0);
                    }
                }
                else
                {
                    if (ball.transform.position.x < -0.5f)
                    {
                        if (dif < 0)
                        {
                            move(1f);
                        }
                        else if (dif > 0)
                        {
                            move(-1f);
                        }
                        else
                        {
                            move(0);
                        }
                    }
                    else
                    {
                        move(0);
                    }
                }
            }
            else
            {
                move(0);
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
    public void move(int side)
    {
        moveX = side;
    }

    public void startgigantPU()
    {
        StartCoroutine(gigantPU());
    }
    IEnumerator gigantPU()
    {
        //transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        for (float s = 1; s < 1.5f; s = s + 0.01f)
        {
            transform.localScale = new Vector3(s, s, 1);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(10);
        //ansform.localScale = new Vector3(1f, 1f, 1f);tr
        for (float s = 1.5f; s > 1f; s = s - 0.01f)
        {
            transform.localScale = new Vector3(s, s, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator randDifC(float min, float max)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 5f));
            difC = Random.Range(min, max);
        }
    }
}
