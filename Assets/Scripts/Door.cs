using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    HingeJoint2D hinge;
    bool PlayerUsingDoor = false;
    public float CloseSpeed = 5f;
    public float CloseSpeedMax = 200f;
    //private Vector3 initialPosition = Vector3.zero;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().centerOfMass = Vector2.zero;
        //initialPosition = transform.position;
        hinge = GetComponent<HingeJoint2D>();
    }

    void FixedUpdate()
    {
        //transform.position = initialPosition;
        
        if (!PlayerUsingDoor)
        {
            float angle = hinge.jointAngle;
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = -angle * CloseSpeed;
            motor.maxMotorTorque = CloseSpeedMax;
            hinge.motor = motor;
        }
        else
        {
            //transform.position = initialPosition;
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = 0f;
            motor.maxMotorTorque = 0f;
            hinge.motor = motor;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerUsingDoor = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerUsingDoor = false;
        }
    }
}
