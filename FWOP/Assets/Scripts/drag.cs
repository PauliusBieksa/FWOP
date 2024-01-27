using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    public float drag_multiplier;

    public measure_dist dist_left;
    public measure_dist dist_right;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(0, (dist_left.dist + dist_right.dist) * (dist_left.dist + dist_right.dist) * drag_multiplier * -rb.velocity.y));
    }
}
