using UnityEngine;
using UnityEngine.InputSystem;

public class InteractObjectCursor : MonoBehaviour
{
    
    public LayerMask LayerMask;
    public Camera cam;
    public Camera cam2;

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        Vector2 MouseWPO = cam.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(MouseWPO, Vector2.zero);
        
        Vector3 WorldPos = cam.ScreenToWorldPoint(MousePos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Collider2D collider = Physics2D.OverlapPoint(WorldPos, LayerMask);
            if (collider)
            {
                Debug.Log("has Interacted With Card Reader");
                cam.targetDisplay = 1;
                cam2.targetDisplay = 0;
                Cursor.visible = true;
            }
        }
    }
}
