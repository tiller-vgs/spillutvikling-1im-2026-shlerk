using UnityEngine;
using UnityEngine.InputSystem;

public class RotateReception : MonoBehaviour
{
    public Camera cam;
    private bool bisturned;
    private Keyboard keyboard = Keyboard.current;
    
    // Update is called once per frame
    void Update()
    {
        /*
        if (cam.targetDisplay == 0)
        {
            Debug.Log("Bisturned2123r3r4g34rg34g3rg34g");
            if (keyboard.dKey.wasPressedThisFrame && !bisturned)
            {
                bisturned = true;
                transform.rotation = Quaternion.Euler(0,-90,0);
            }

            if (keyboard.aKey.wasPressedThisFrame && bisturned)
            {
                bisturned = false;
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        */
    }
}
