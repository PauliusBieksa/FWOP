using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 scroll_up_start_pos;
    public Vector3 scroll_up_end_pos;
    public float pre_scroll_up_override_timer;

    private Transform player_torso;
    private player_controller player_script;

    private float scroll_up_duration;
    private float animation_duration;

    Camera ThisCam;
    float CamSizeStart;
    public float CamSizeEnd = 6;

    // Start is called before the first frame update
    void Start()
    {
        player_torso = GameObject.Find("Player").transform;
        player_script = GameObject.Find("Player").GetComponent<player_controller>();

        scroll_up_duration = player_script.pre_animation_timer;
        animation_duration = player_script.animation_timer;

        ThisCam = GetComponent<Camera>();
        CamSizeStart = ThisCam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_script.pre_jump)
        {
            if (pre_scroll_up_override_timer >= 0)
            {
                transform.position = scroll_up_start_pos;
                pre_scroll_up_override_timer -= Time.deltaTime;
                player_script.pre_animation_timer = scroll_up_duration;
            }
            else
            {
                if (player_script.pre_animation_timer >= 0)
                {
                    float t = 1 - (player_script.pre_animation_timer / scroll_up_duration);
                    t = t * Mathf.PI;
                    t = Mathf.Cos(Mathf.Clamp(t, 0, Mathf.PI));
                    t = 1 - ((t + 1) / 2f);
                    transform.position = Vector3.Lerp(scroll_up_start_pos, scroll_up_end_pos, t);
                }
                else
                {
                    float t = 1 - (player_script.animation_timer / animation_duration);
                    t = t * Mathf.PI;
                    t = Mathf.Cos(t);
                    t = 1 - ((t + 1) / 2f);
                    transform.position = Vector3.Lerp(scroll_up_end_pos, new Vector3(transform.position.x, player_torso.position.y, transform.position.z) + offset, t);
                    ThisCam.orthographicSize = Mathf.Lerp(CamSizeStart, CamSizeEnd, t);
                }
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, player_torso.position.y, transform.position.z) + offset;
        }
    }
}
