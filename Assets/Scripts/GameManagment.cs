using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagment : MonoBehaviour
{
    public GameObject ball;
    public GameObject p1b;
    public GameObject p2b;
    public GameObject ballSpawner;
    public Text text;
    public Text touches;
    public bool isAndroid = false;
    public int t;
    public Animator animation;

    private int left;
    private int right;
    private int t2;
    private Transform ballTransform;
    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = ball.GetComponent<Transform>();
        ballRb = ball.GetComponent<Rigidbody2D>();
        p1b.SetActive(false);
        p2b.SetActive(false);
        ballRespawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAndroid)
        {
            p1b.SetActive(true);
            p2b.SetActive(true);
        }
        text.text = left + " : " + right;
        touches.text = "X " + t;
        if (t != t2)
        {
            animation.SetBool("isPlay", true);
            StartCoroutine(anim());
        }

        t2 = t;
    }

    public void BallFallLeft()
    {
        right++;
        ballRespawn();
    }

    public void BallFallRight()
    {
        left++;
        ballRespawn();
    }

    public void ballRespawn()
    {
        ballRb.velocity = Vector2.zero;
        ballTransform.position = ballSpawner.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 0, 0);
    }

    IEnumerator anim()
    {
        yield return new WaitForSeconds(0.30f);
        animation.SetBool("isPlay", false);
    }
}
