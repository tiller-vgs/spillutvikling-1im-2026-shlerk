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
    public CharacterMainScript PlayerScript;
    private bool IsActive;
    
    /*
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        PlayerScript.GameObject().GetComponent<CharacterMainScript>().IsInteractActive = true;
    }
    */
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        transform.rotation = Quaternion.Euler(Mathf.Clamp(((ViewPos.y-transform.position.y)*-1)*followstrength,max*-1,max),Mathf.Clamp(((ViewPos.x-transform.position.x)/1.75f)*followstrength,max*-1,max), 0);

        var keyboard = Keyboard.current;
        
        if (cam.targetDisplay == 0)
        {
            
            if (keyboard.eKey.wasPressedThisFrame && PlayerScript.GameObject().GetComponent<CharacterMainScript>().isInteractActive)
            {
                PlayerScript.GameObject().GetComponent<CharacterMainScript>().isInteractActive = false;
                StartCoroutine(PlayerScript.GameObject().GetComponent<CharacterMainScript>().ResetInteract());
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