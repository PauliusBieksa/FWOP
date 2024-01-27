using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class drag : MonoBehaviour
{
    public float drag_multiplier;

    public measure_dist dist_left;
    public measure_dist dist_right;

    private Rigidbody2D rb;
    bool IsTorso;

    static Vector2 Drag = Vector2.zero;

    private static Action<Vector2> OnDragCalc;

    Collider2D[] Colliders;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Colliders = GetComponentsInChildren<Collider2D>();
        IsTorso = (transform.parent == null);
    }

    private void OnEnable()
    {
        OnDragCalc += ApplyDrag;
    }
    
    private void OnDisable()
    {
        OnDragCalc -= ApplyDrag;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsTorso)
        {
            return;
        }
        Debug.Log(rb.velocity.y);
        Bounds bounds = Colliders[0].bounds;
        for (int i = 1; i < Colliders.Length; i++)  
        {
            bounds.Encapsulate(Colliders[i].bounds);
        }
        Debug.Log($"bound:{bounds.extents.x * 2}, dists:{dist_left.dist + dist_right.dist}");

        Drag = new Vector2(0, (bounds.extents.x * 2) * (bounds.extents.x * 2) * drag_multiplier * -rb.velocity.y);
        OnDragCalc?.Invoke(Drag);
       // Drag = new Vector2(0, (dist_left.dist + dist_right.dist) * (dist_left.dist + dist_right.dist) * drag_multiplier * -rb.velocity.y);

    }

    private void ApplyDrag(Vector2 drag)
    {
        rb.AddForce(drag);        
    }
}
