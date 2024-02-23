using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed ;
    public Transform[] points;
    private int currentPoint;
    float horizontalSpeed = 10;
    float verticalSpeed = 10;
    public enum Mode
    {
        Automatic,
        Manual
    };
    public Mode mode;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bat dau Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.Automatic)
        {
            if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.3f)
            {
                currentPoint++;
            }
            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, Time.deltaTime * speed);
            transform.LookAt(points[currentPoint].position);
        }
        else if (mode == Mode.Manual)
        {
            float h = horizontalSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            float v = verticalSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.Translate(0, 0, v);
            transform.Rotate(0, h, 0);
        }
    }
}
