using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour
{
    public GameManagment gameManagment;
    public int lTouches = 0;
    public int rTouches = 0;
    public int touches = 0;

    void Start() { }
    void LateUpdate()
    {
        if (lTouches > 10)
        {
            gameManagment.ballRespawn();
            lTouches = 0;
        }
        if (rTouches > 10)
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
        }

        if (other.gameObject.tag == "Right")
        {
            gameManagment.BallFallRight();
            rTouches = 0;
            lTouches = 0;
            touches = 0;
        }

        if (other.gameObject.tag == "Player1")
        {
            lTouches++;
            touches++;
            rTouches = 0;
        }

        if (other.gameObject.tag == "Player2")
        {
            rTouches++;
            touches++;
            lTouches = 0;
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
}
