using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class measure_dist : MonoBehaviour
{

    public float dist;
    public bool is_left;

    public Transform torso;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, torso.position.y, 0);
        if (is_left)
        {
            rb.AddForce(new Vector2(0.001f, 0));
        }
        else
        {
            rb.AddForce(new Vector2(-0.001f, 0));
        }
        dist = is_left ? torso.position.x - transform.position.x : transform.position.x - torso.position.x;
    }
}
