using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CreateGrabableItem : MonoBehaviour
{
    
    public LayerMask LayerMask;
    public Camera cam;
    public GameObject PhysicsObj;
    public GameObject PhysicsController;

    private bool bCreatedObj = false;
    
    
    IEnumerator ResetCreatedObj()
    {
        yield return new WaitForSeconds(1f);
        bCreatedObj = false;
    }
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
        Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

        if (Mouse.current.leftButton.wasPressedThisFrame && !bCreatedObj)
        {
            Collider2D collider = Physics2D.OverlapPoint(WorldPos, LayerMask);
            if (collider)
            {
                StartCoroutine(ResetCreatedObj());
                bCreatedObj = true;
                Debug.Log("hasInteracted with Cloth");
                Instantiate(PhysicsObj, WorldPos, transform.rotation);
                PhysicsController.GameObject().GetComponent<DragAndDropAuto>().AttachPhysics();
            }
        }
    }
}
