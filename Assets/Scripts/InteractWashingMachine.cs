using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWashingMachine : MonoBehaviour
{
    
    public Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.targetDisplay == 0)
        {
            Vector3 MousePos = Mouse.current.position.ReadValue();
            MousePos.z = Mathf.Abs(cam.transform.position.z);
            Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
            RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
            Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("SIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMASIGMA");
            }
        }
    }
}
