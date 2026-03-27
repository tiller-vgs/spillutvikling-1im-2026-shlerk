using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class FollowCursor : MonoBehaviour
{

    public float followstrength = 1;
    public Camera cam;
    public Camera cam2;
    public bool goBackToPlayer;
    public float max;
    private Vector2 aspectRatio = new Vector2(16, 9);
    public CharacterMainScript PlayerScript;
    private Keyboard keyboard = Keyboard.current;
    public float turn = 0;
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        
        
        
        transform.rotation = Quaternion.Euler(Mathf.Clamp((((ViewPos.y-transform.position.y)/aspectRatio.y)*-1)*followstrength,max*-1,max),( turn <= 45 ? Mathf.Clamp(((ViewPos.x-transform.position.x)/aspectRatio.x)*followstrength,(max+turn)*-1,max+turn)+turn : Mathf.Clamp(((ViewPos.z-transform.position.z)/aspectRatio.x)*-followstrength,(max+turn)*-1,max+turn)+turn), 0);
        
        //Debug.Log(ViewPos);
        if (cam.targetDisplay == 0)
        {
            if (keyboard.eKey.wasPressedThisFrame && PlayerScript.GetComponent<CharacterMainScript>().isInteractActive)
            {
                PlayerScript.GetComponent<CharacterMainScript>().isInteractActive = false;
                StartCoroutine(PlayerScript.GetComponent<CharacterMainScript>().ResetInteract());
                cam.targetDisplay = 1;
                cam2.targetDisplay = 0;
                if (goBackToPlayer)
                {
                    PlayerScript.enabled = true;
                    Cursor.visible = false;
                }
            }
        }
    }
}
