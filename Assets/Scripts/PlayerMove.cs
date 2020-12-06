using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private Rigidbody2D rb;

    public bool autoJump = true;
    public float speed;
    public float thrust;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //moveX = Input.GetAxis("Horizontal");
        if (Input.GetKey(left))
        {
            moveX = -1;
        }
        else if (Input.GetKey(right))
        {
            moveX = 1;
        }
        else
        {
            moveX = 0;
        }

        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.fixedDeltaTime);
        if(Input.GetKeyDown(jump))
        {
            pjump();
        }
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
}
