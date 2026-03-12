using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class OverlappBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    public Camera cam2;
    private bool bisOverlapping = false;
    public CharacterMainScript PlayerScript;
    private bool IsActive;
    
    private Keyboard keyboard = Keyboard.current;
    /*
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        PlayerScript.GameObject().GetComponent<CharacterMainScript>().IsInteractActive = true;
    }
    */
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
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

    void SwitchScene()
    {
        //Debug.Log("TESTESTESTESTESTESTESTSESTSETSETES");
        //bytte kamera
        PlayerScript.GameObject().GetComponent<CharacterMainScript>().isInteractActive = false;
        StartCoroutine(PlayerScript.GameObject().GetComponent<CharacterMainScript>().ResetInteract());
        cam.targetDisplay = 0;
        cam2.targetDisplay = 1;
        Cursor.visible = true;
        PlayerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.targetDisplay == 0)
        {
            if (bisOverlapping)
            {
                if (keyboard.eKey.wasPressedThisFrame && PlayerScript.isInteractActive)
                {
                    //Debug.Log(PlayerScript.GameObject().GetComponent<CharacterMainScript>().isInteractActive);
                    SwitchScene();
                }

            }
            
        }
        Debug.Log(PlayerScript.isInteractActive);
    }
}
