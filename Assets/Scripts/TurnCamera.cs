using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class TurnCamera : MonoBehaviour
{


    public Camera cam;
    private bool bisturned;
    private Keyboard keyboard = Keyboard.current;
    public FollowCursor followCursor;
    
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
                followCursor.GetComponent<FollowCursor>().turn = 90;
            }

            if (keyboard.aKey.wasPressedThisFrame && bisturned)
            {
                bisturned = false;
                followCursor.GetComponent<FollowCursor>().turn = 0;
            }
        }
        */
    }
}
