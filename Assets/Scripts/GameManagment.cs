using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public GameObject ball;
    public GameObject p1b;
    public GameObject p2b;
    public GameObject ballSpawner;
    public Text text;
    public bool isAndroid;

    private int left;
    private int right;
    private Transform ballTransform;
    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = ball.GetComponent<Transform>();
        ballRb = ball.GetComponent<Rigidbody2D>();
        p1b.SetActive(false);
        p2b.SetActive(false);
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

    private void ballRespawn()
    {
        ballRb.velocity = Vector2.zero;
        ballTransform.position = ballSpawner.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, 0);
    }
}
