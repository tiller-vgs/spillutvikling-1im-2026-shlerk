using UnityEngine;
using UnityEngine.InputSystem;

public class LogicManager : MonoBehaviour
{
    public uint score;
    public bool isPaused;

    void Update()
    {
        if(isPaused){ Time.timeScale = 0f; }
        else{ Time.timeScale = 1f; }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            switch (isPaused)
            {
                case false: isPaused = true; break;
                case true: isPaused = false; break;
            }
        }
    }
}
