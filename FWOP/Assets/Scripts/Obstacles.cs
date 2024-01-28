using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    private List<float> y_size = new List<float>();
    public Transform plank;
    public float obstacle_start_x;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            y_size[i] = obstacles[i].GetComponent<Collider2D>().bounds.size.y * 2;
        }
        float working_pos = plank.position.y;
        while (working_pos > 10f)
        {
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], new Vector3(obstacle_start_x, working_pos - y_size[index], 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
