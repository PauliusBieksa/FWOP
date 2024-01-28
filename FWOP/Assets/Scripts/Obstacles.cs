using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> obstacle_prefabs = new List<GameObject>();
    private List<float> y_size = new List<float>();
    public Transform plank;
    public float obstacle_start_x;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<Rigidbody2D> obstacle_rbs = new List<Rigidbody2D>();
    public float movement_force;
    private List<bool> left = new List<bool>();

    private bool first_frame = true;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < obstacle_prefabs.Count; i++)
        //{
        //    y_size.Add(obstacle_prefabs[i].GetComponent<Collider2D>().bounds.size.y * 2);
        //    Debug.Log(y_size[i]);
        //}
        y_size.Add(4f); // ayy lmao
        y_size.Add(0.5f); // ball
        y_size.Add(1f); // seagull
        y_size.Add(0.5f); // drone
        y_size.Add(14f); // baloon
        y_size.Add(3f); // kite

        float working_pos = plank.position.y;
        //int test = 10;
        while (working_pos > 10f)
        {
            int index = Random.Range(0, obstacle_prefabs.Count);
            obstacles.Add(Instantiate(obstacle_prefabs[index], new Vector3(obstacle_start_x + Random.Range(0f, 20f), working_pos - (y_size[index]/2), 0), Quaternion.identity, transform));
           // obstacle_rbs.Add(obstacles[index].GetComponent<Rigidbody2D>());
            left.Add(true);
            working_pos -= y_size[index] + 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (first_frame)
        {
            foreach (GameObject ob in obstacles)
                obstacle_rbs.Add(ob.GetComponent<Rigidbody2D>());
            first_frame = false;
        }
        int i = 0;
        foreach (Rigidbody2D rb in obstacle_rbs)
        {
            if (rb.position.x > -10f && left[i])
            {
                rb.velocity = new Vector2(-movement_force - Random.Range(0f, 3f), 0);
                //rb.AddForce(new Vector2(-movement_force, 0), ForceMode2D.Impulse);
            }
            if (rb.position.x < 10 && !left[i])
            {
                //rb.AddForce(new Vector2(movement_force, 0), ForceMode2D.Impulse);
                rb.velocity = new Vector2(movement_force + Random.Range(0f, 3f), 0);
            }
            if (rb.position.x < -10) left[i] = false;
            if (rb.position.x > 10) left[i] = true;

            i++;
        }
    }
}
