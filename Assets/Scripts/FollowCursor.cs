using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{

    public float followstrength = 1;
    public Camera cam;
    public float max;
    
    void Update()
    {
        // roterer kameraet til muse posisjonen in view
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = Mathf.Abs(cam.transform.position.z);
        var ViewPos = cam.ScreenToWorldPoint(MousePos);
        transform.rotation = Quaternion.Euler(Mathf.Clamp(((ViewPos.y-transform.position.y)*-1)*followstrength,max*-1,max),Mathf.Clamp(((ViewPos.x-transform.position.x)/1.75f)*followstrength,max*-1,max), 0);
        
        //Debug.Log(ViewPos);
    }
}
