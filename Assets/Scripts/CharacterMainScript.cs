using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMainScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float playerSpeed;
    public float playerRotation;
    private bool Iscontrolling = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // laga av marius
        var keyboard = Keyboard.current;
                float moveY = 0f;
                float moveX = 0f;

                if (Iscontrolling)
                {
                    
                    if (keyboard.aKey.isPressed)
                        moveY = -1f;
                    if (keyboard.dKey.isPressed)
                        moveY = 1f;
                    if (keyboard.wKey.isPressed)
                        moveX = 1f;
                    if (keyboard.sKey.isPressed)
                        moveX = -1f;
        
                    Vector2 MovementDir = new Vector2(moveY, moveX);
                    float inputMagnitude = Mathf.Clamp(MovementDir.magnitude,0,1);
                    MovementDir.Normalize();
        
                    // laga av Eivind
                    // roterer karakter spriten mot gå retningen til spilleren
                    if (MovementDir != Vector2.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward , MovementDir);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, playerRotation * Time.deltaTime);
                    }
                    rb.linearVelocity = new Vector2(moveY * playerSpeed, moveX * playerSpeed);
                }
        
    }
}
