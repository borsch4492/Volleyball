using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D rb;
    private const bool isAndroid = true;

    public bool autoJump = true;
    public float speed;
    public float thrust;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public GameManagment gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm.isAndroid = isAndroid;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //moveX = Input.GetAxis("Horizontal");
        if (!isAndroid)
        {
            if (Input.GetKey(left))
            {
                move(-1);
            }
            else if (Input.GetKey(right))
            {
                move(1);
            }
            else
            {
                move(0);
            }
            if (Input.GetKeyDown(jump))
            {
                pjump();
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

    public void move(int side)
    {
        moveX = side;
    }
}
