using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{

    public float followstrength = 1;
    public Camera cam;
    public Camera cam2;
    public bool goBackToPlayer;
    public float max;
    public CharacterMainScript PlayerScript;
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        transform.rotation = Quaternion.Euler(Mathf.Clamp(((ViewPos.y-transform.position.y)*-1)*followstrength,max*-1,max),Mathf.Clamp(((ViewPos.x-transform.position.x)/1.75f)*followstrength,max*-1,max), 0);

        var keyboard = Keyboard.current;

        Debug.Log(cam.targetDisplay);
        
        if (cam.targetDisplay == 0)
        {
            if (keyboard.eKey.isPressed)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                cam.targetDisplay = 1;
                cam2.targetDisplay = 0;
                if (goBackToPlayer)
                {
                    PlayerScript.enabled = true;
                    Cursor.visible = false;
                }
                
            }
        }
        //Debug.Log(ViewPos);
    }
    
    
    // legg te en variable for main andre kamera og når du trykke på e så bli du sendt tilbake plus en bool om det ska vis cursor eller ikke
}