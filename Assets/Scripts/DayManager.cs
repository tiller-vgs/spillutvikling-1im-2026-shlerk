using UnityEngine;
using UnityEngine.SceneManagement; 
using System;
public class DayManager : MonoBehaviour
{
    public static event Action OnNewDay; 

    public float dayLength = 300f; 
    private float timer;
    public int currentDay = 1;

    void Start()
    {
        timer = dayLength;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            NextDay();
        }
    }

 void NextDay()
{
    currentDay++;
    timer = dayLength + timer;
    Debug.Log("New Day: " + currentDay);
    OnNewDay?.Invoke();
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}
