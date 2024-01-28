using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Rigidbody2D player;
    public float player_speed;
    public float player_torque;
    public float player_joint_force;

    public bool pre_jump = true;
    public Vector3 animation_start_pos;
    public Vector3 animation_end_pos;
    public float pre_animation_timer;
    public float animation_timer;
    public float board_roll_up_speed;

    public HingeJoint2D shoulder1_object;
    public HingeJoint2D shoulder2_object;
    public HingeJoint2D elbow1_object;
    public HingeJoint2D elbow2_object;
    public HingeJoint2D hip1_object;
    public HingeJoint2D hip2_object;
    public HingeJoint2D knee1_object;
    public HingeJoint2D knee2_object;
    public HingeJoint2D foot1_object;
    public HingeJoint2D foot2_object;

    private float animation_legth;

    // Start is called before the first frame update
    void Start()
    {
        JointMotor2D mot_clk = new JointMotor2D();
        JointMotor2D mot_cclk = new JointMotor2D();
        mot_clk.maxMotorTorque = 100;
        mot_cclk.maxMotorTorque = 100;
        mot_clk.motorSpeed = player_joint_force;
        mot_cclk.motorSpeed = -player_joint_force;
        shoulder1_object.motor = mot_clk;
        shoulder2_object.motor = mot_clk;
        elbow1_object.motor = mot_cclk;
        elbow2_object.motor = mot_cclk;
        hip1_object.motor = mot_cclk;
        hip2_object.motor = mot_cclk;
        knee1_object.motor = mot_clk;
        knee2_object.motor = mot_clk;
        foot1_object.motor = mot_cclk;
        foot2_object.motor = mot_cclk;

        animation_legth = animation_timer;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (pre_jump)
        {
            if (pre_animation_timer <= 0)
            {
                if (animation_timer <= 0)
                {
                    if (Input.GetButton("ball_up"))
                    {
                        player.constraints = RigidbodyConstraints2D.None;
                        pre_jump = false;
                    }
                    else
                    {
                        transform.position = animation_end_pos;
                        player.constraints = RigidbodyConstraints2D.FreezeRotation;
                        return;
                    }
                }
                animation_timer -= Time.deltaTime;

                transform.position = Vector3.Lerp(animation_start_pos, animation_end_pos, 1 - (animation_timer / animation_legth));
                player.angularVelocity = board_roll_up_speed;
            }
            else
            {
                transform.position = animation_start_pos;
            }
            pre_animation_timer -= Time.deltaTime;
        }
        else
        {
            JointMotor2D mot_clk = new JointMotor2D();
            JointMotor2D mot_cclk = new JointMotor2D();
            mot_clk.maxMotorTorque = 100;
            mot_cclk.maxMotorTorque = 100;
            mot_clk.motorSpeed = player_joint_force;
            mot_cclk.motorSpeed = -player_joint_force;
            if (Input.GetAxis("Horizontal") < 0) player.AddForce(new Vector2(-player_speed * Time.deltaTime, 0), ForceMode2D.Impulse);
            if (Input.GetAxis("Horizontal") > 0) player.AddForce(new Vector2(player_speed * Time.deltaTime, 0), ForceMode2D.Impulse);
            if (Input.GetAxis("rotate") < 0) player.AddTorque(player_torque);
            if (Input.GetAxis("rotate") > 0) player.AddTorque(-player_torque);
            if (Input.GetButton("ball_up"))
            {
                shoulder1_object.motor = mot_clk;
                shoulder2_object.motor = mot_clk;
                elbow1_object.motor = mot_cclk;
                elbow2_object.motor = mot_cclk;
                hip1_object.motor = mot_cclk;
                hip2_object.motor = mot_cclk;
                knee1_object.motor = mot_clk;
                knee2_object.motor = mot_clk;
                foot1_object.motor = mot_cclk;
                foot2_object.motor = mot_cclk;
            }
            else
            {
                shoulder1_object.motor = mot_cclk;
                shoulder2_object.motor = mot_cclk;
                elbow1_object.motor = mot_clk;
                elbow2_object.motor = mot_clk;
                hip1_object.motor = mot_clk;
                hip2_object.motor = mot_clk;
                knee1_object.motor = mot_cclk;
                knee2_object.motor = mot_cclk;
                foot1_object.motor = mot_clk;
                foot2_object.motor = mot_clk;
            }
        }
    }
}
