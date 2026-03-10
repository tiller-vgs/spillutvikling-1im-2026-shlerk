using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    HingeJoint2D hinge;
    Rigidbody2D rb;
    bool PlayerUsingDoor = false;
    public float CloseSpeed = 5f;
    public float CloseSpeedMax = 200f;

    public AudioClip[] creakSounds;
    public float creakVolumeMultiplier = 1f;
    public float creakAngleChangeThreshold = 0.5f; // degrees/frame til å trigger creak
    public float creakCooldown = 0.3f;

    private float lastCreakTime = 0f;
    private float lastAngle = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = Vector2.zero;
        hinge = GetComponent<HingeJoint2D>();
        lastAngle = hinge.jointAngle;
    }

    void FixedUpdate()
    {
        float angle = hinge.jointAngle;
        float angleDelta = Mathf.Abs(angle - lastAngle);

        if (!PlayerUsingDoor)
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = -angle * CloseSpeed;
            motor.maxMotorTorque = CloseSpeedMax;
            hinge.motor = motor;
        }
        else
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = 0f;
            motor.maxMotorTorque = 0f;
            hinge.motor = motor;
        }

        TryPlayCreak(angleDelta);
        lastAngle = angle;
    }

    void TryPlayCreak(float angleDelta)
    {
        if (creakSounds == null || creakSounds.Length == 0) return;
        if (Time.time - lastCreakTime < creakCooldown) return;
        if (angleDelta < creakAngleChangeThreshold) return;

        lastCreakTime = Time.time;

        AudioClip clip = creakSounds[Random.Range(0, creakSounds.Length)];

        float t = Mathf.InverseLerp(creakAngleChangeThreshold, 5f, angleDelta);
        float volume = Mathf.Lerp(0.2f, 1f, t) * creakVolumeMultiplier;

        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayerUsingDoor = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayerUsingDoor = false;
    }
}