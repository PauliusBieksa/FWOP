using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Rigidbody2D player;
    public float player_speed;
    public float player_torque;
    public float player_joint_force;

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

    private JointMotor2D shoulder1_motor;
    private JointMotor2D shoulder2_motor;
    private JointMotor2D elbow1_motor;
    private JointMotor2D elbow2_motor;
    private JointMotor2D hip1_motor;
    private JointMotor2D hip2_motor;
    private JointMotor2D knee1_motor;
    private JointMotor2D knee2_motor;
    private JointMotor2D foot1_motor;
    private JointMotor2D foot2_motor;

    // Start is called before the first frame update
    void Start()
    {
        shoulder1_motor = shoulder1_object.motor;
        shoulder2_motor = shoulder2_object.motor;
        elbow1_motor = elbow1_object.motor;
        elbow2_motor = elbow2_object.motor;
        hip1_motor = hip1_object.motor;
        hip2_motor = hip2_object.motor;
        knee1_motor = knee1_object.motor;
        knee2_motor = knee2_object.motor;
        foot1_motor = foot1_object.motor;
        foot2_motor = foot2_object.motor;
    }
    // Update is called once per frame
    void Update()
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