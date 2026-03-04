using UnityEngine;
using UnityEngine.InputSystem;

public class OverlappBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    public Camera cam2;
    private bool bisOverlapping = false;
    public CharacterMainScript PlayerScript;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            bisOverlapping = true;
        }
        else
        {
            bisOverlapping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        bisOverlapping = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bisOverlapping)
        {
            var keyboard = Keyboard.current;
            if (keyboard.eKey.isPressed)
            {
                //bytte kamera'
                cam.targetDisplay = 0;
                cam2.targetDisplay = 1;
                Cursor.visible = true;
                PlayerScript.enabled = false;
            }

        }
        
    }
}
