using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{

    public float followstrength = 1;
    public Camera cam;
    public float max;
    private Vector2 aspectRatio = new Vector2(16, 9);
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        transform.rotation = Quaternion.Euler(Mathf.Clamp((((ViewPos.y-transform.position.y)/aspectRatio.y)*-1)*followstrength,max*-1,max),Mathf.Clamp(((ViewPos.x-transform.position.x)/aspectRatio.x)*followstrength,max*-1,max), 0);
        
        //Debug.Log(ViewPos);
    }
}
