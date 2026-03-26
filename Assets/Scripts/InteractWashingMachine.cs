using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWashingMachine : MonoBehaviour
{
    
    public Camera cam;
    public LayerMask LayerMask;
    public WashingMachineScript washingMachine;
    public CreateGrabableItem createGrabableItem;

    public bool startwash = true;

    void Update()
    {
        if (cam.targetDisplay == 0)
        {
            Vector3 MousePos = Mouse.current.position.ReadValue();
            MousePos.z = Mathf.Abs(cam.transform.position.z);
            Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
            RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
            Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

            Collider2D collider = Physics2D.OverlapPoint(WorldPos, LayerMask);
            if (Mouse.current.leftButton.wasPressedThisFrame && collider)
            {
                washingMachine.GetComponent<WashingMachineScript>().OpenWashingMachine();
                Mathf.Clamp(washingMachine.GetComponent<WashingMachineScript>().CleanClothing++, 0,5);
                createGrabableItem.GetComponent<CreateGrabableItem>().CanInteract = true;
                startwash = false;
            }
        }
    }
}
