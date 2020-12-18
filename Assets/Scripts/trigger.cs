using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour
{
    public GameManagment gameManagment;
    public int lTouches = 0;
    public int rTouches = 0;
    public int touches = 0;
    public bool isPowerUps;
    public PlayerMove P1;
    public PlayerMove P2;
    public Rigidbody2D ball;
    public GameObject LeftBlock;
    public GameObject RightBlock;
    public TrailRenderer trail;

    private const int n = 7;

    void Start() { }
    void LateUpdate()
    {

        if (lTouches > n)
        {
            gameManagment.ballRespawn();
            lTouches = 0;
        }
        if (rTouches > n)
        {
            gameManagment.ballRespawn();
            rTouches = 0;
        }

        gameManagment.t = touches;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Left")
        {
            gameManagment.BallFallLeft();
            rTouches = 0;
            lTouches = 0;
            touches = 0;
            trail.startColor = new Color(255, 255, 255, 255);
            trail.endColor = new Color(255, 255, 255, 255);
        }

        if (other.gameObject.tag == "Right")
        {
            gameManagment.BallFallRight();
            rTouches = 0;
            lTouches = 0;
            touches = 0;
            trail.startColor = new Color(255, 255, 255, 255);
            trail.endColor = new Color(255, 255, 255, 255);
        }

        if (other.gameObject.tag == "Player1")
        {
            lTouches++;
            touches++;
            rTouches = 0;
            if (isPowerUps)
            {
                trail.startColor = new Color(0, 0, 255, 255);
                trail.endColor = new Color(0, 0, 255, 255);
            }
        }

        if (other.gameObject.tag == "Player2")
        {
            rTouches++;
            touches++;
            lTouches = 0;
            if (isPowerUps)
            {
                trail.startColor = new Color(255, 0, 0, 255);
                trail.endColor = new Color(255, 0, 0, 255);
            }
        }

        if (other.gameObject.tag == "BigPlayer")
        {
            Destroy(other.gameObject);

            if (rTouches > 0)
            {
                P2.startgigantPU();
            }
            else if (lTouches > 0)
            {
                P1.startgigantPU();
            }
        }

        if (other.gameObject.tag == "SupBall")
        {
            Destroy(other.gameObject);
            StartCoroutine(SuperBall());
        }

        if (other.gameObject.tag == "RelBall")
        {
            Destroy(other.gameObject);
            gameManagment.ballRespawn();
        }

        if (other.gameObject.tag == "BlockBall")
        {
            Destroy(other.gameObject);

            if (rTouches > 0)
            {
                StartCoroutine(Block(false));
            }
            else if (lTouches > 0)
            {
                StartCoroutine(Block(true));
            }
        }

        if (other.gameObject.tag == "DeSpeedTime")
        {
            // Time.timeScale =
            Destroy(other.gameObject);

            StartCoroutine(DeSpeedTime());
        }
    }


    IEnumerator deStuck()
    {
        while (true)
        {
            Vector2 pos = transform.position;
            Vector2 pos2 = pos;
            yield return new WaitForSeconds(1);
            if (pos == pos2)
            {
                gameManagment.ballRespawn();
            }
        }
    }

    IEnumerator SuperBall()
    {
        for (float g = 1; g > 0.75f; g = g - 0.005f)
        {
            ball.gravityScale = g;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(15f);

        for (float g = 0.75f; g < 1f; g = g + 0.005f)
        {
            ball.gravityScale = g;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Block(bool side) // true - Left, false - Right
    {
        if (side)
        {
            LeftBlock.SetActive(true);
        }
        else
        {
            RightBlock.SetActive(true);
        }

        yield return new WaitForSeconds(7f);

        if (side)
        {
            LeftBlock.SetActive(false);
        }
        else
        {
            RightBlock.SetActive(false);
        }
    }

    IEnumerator DeSpeedTime()
    {
        for (float g = 1; g > 0.60f; g = g - 0.01f)
        {
            Time.timeScale = g;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(10f);

        for (float g = 0.60f; g < 1f; g = g + 0.01f)
        {
            Time.timeScale = g;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
