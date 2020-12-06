using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameManagment gameManagment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Left")
        {
            gameManagment.BallFallLeft();
        }

        if (other.gameObject.tag == "Right")
        {
            gameManagment.BallFallRight();
        }
    }

}
