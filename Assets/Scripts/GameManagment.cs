using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagment : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballSpawner;
    public Text text;

    private int left;
    private int right;
    private Transform ballTransform;
    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = ball.GetComponent<Transform>();
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
