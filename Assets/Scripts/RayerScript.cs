using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMove playerMove;

    private float maxDist = 0;
    private Color col;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.hitInfo.distance > maxDist)
        {
            maxDist = playerMove.hitInfo.distance;
        }
        //col = new Color(0, convert(maxDist, 255, playerMove.hitInfo.distance), 0, 255);
        //print(convert(maxDist, 255, playerMove.hitInfo.distance));
        transform.position = playerMove.transform.position;
        Debug.DrawRay(playerMove.transform.position + new Vector3(playerMove.difC, 1), transform.TransformDirection(Vector2.up) * playerMove.hitInfo.distance, Color.yellow);
    }

    private float convert(float _input_range_max, float _output_range_max, float _input_value_tobe_converted)
    {
        float diffOutputRange = Mathf.Abs((_output_range_max - 0));
        float diffInputRange = Mathf.Abs((_input_range_max - 0));
        float convFactor = (diffOutputRange / diffInputRange);
        return (0 + (convFactor * (_input_value_tobe_converted - 0)));
    }
}
