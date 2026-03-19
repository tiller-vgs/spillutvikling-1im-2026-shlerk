using UnityEngine;
using UnityEngine.InputSystem;

public class TurnCamera : MonoBehaviour
{


    public Camera cam;
    private bool bisturned;
    private Keyboard keyboard = Keyboard.current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.targetDisplay == 0)
        {
            Debug.Log("Bisturned2123r3r4g34rg34g3rg34g");
            if (keyboard.dKey.wasPressedThisFrame && !bisturned)
            {
                bisturned = true;
                Debug.Log("Bisturneotowejrgoiwejroibnweirnweoirbiusrhbuiwhrtiuhrwuibhwriuthbuwrthuirwhtubhrwtuibhrwtubhwrtiubhwruitbhed");
                cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y+90, cam.transform.rotation.eulerAngles.z);
            }

            if (keyboard.aKey.wasPressedThisFrame && bisturned)
            {
                bisturned = false;
            }
        }
    }
}
