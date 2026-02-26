using UnityEngine;
using UnityEngine.InputSystem;

public class OverlappBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    public Camera cam2;
    private bool isOverlapping = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            isOverlapping = true;
        }
        else
        {
            isOverlapping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOverlapping = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOverlapping)
        {
            var keyboard = Keyboard.current;
            if (keyboard.eKey.isPressed)
            {
                //bytte kamera
                cam.targetDisplay = 0;
                cam2.targetDisplay = 1;
            }

        }
        
    }
}
