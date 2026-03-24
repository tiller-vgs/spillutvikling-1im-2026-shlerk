using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CharacterMainScript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float playerSpeed;
    public float playerRotation;
    public float headRotation;
    private bool Iscontrolling = true;
    public SpriteRenderer headSprite;
    public SpriteRenderer playerSprite;
    public Animator playerAnimator;
    
    public bool isInteractActive = true;
    
    
    public IEnumerator ResetInteract()
    {
        yield return new WaitForSeconds(0.1f);
        isInteractActive = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        isInteractActive = true;
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
                    
                    playerAnimator.speed = new Vector2(rb.linearVelocityX,rb.linearVelocityY).magnitude/40;
                    if (new Vector2(rb.linearVelocityX, rb.linearVelocityY).magnitude == 0)
                    {
                        playerAnimator.Play(0);
                    }
                        
                    //playerAnimator.SetFloat("Speed", new Vector2(rb.linearVelocityX,rb.linearVelocityY).magnitude);
                    //Debug.Log(new Vector2(rb.linearVelocityX,rb.linearVelocityY).magnitude);
                    // laga av Eivind
                    // roterer karakter spriten mot gå retningen til spilleren
                    if (MovementDir != Vector2.zero)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward , MovementDir);
                        playerSprite.transform.rotation = Quaternion.Slerp(playerSprite.transform.rotation, targetRotation, playerRotation * Time.deltaTime);
                        headSprite.transform.rotation = Quaternion.Slerp(headSprite.transform.rotation, targetRotation, headRotation * Time.deltaTime);
                    }
                    rb.linearVelocity = new Vector2(moveY * playerSpeed, moveX * playerSpeed);
                    
                }
        
    }
}
