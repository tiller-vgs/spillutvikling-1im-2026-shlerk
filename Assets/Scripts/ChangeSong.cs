using UnityEngine;
using System.Collections;

public class ChangeSong : MonoBehaviour
{
    public AudioSource Default;
    public AudioSource New;
    public float fade = 2f;
    private bool bIsInside;


    void Start()
    {
        New.volume = 0;
    }
    
    private IEnumerator FadeMusic(AudioSource outSource, AudioSource inSource)
    {
        float time = 0;
        while (time < fade)
        {
            time += Time.deltaTime;
            outSource.volume = Mathf.Lerp(1, 0, time / fade);
            inSource.volume = Mathf.Lerp(0, 1, time / fade);
            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Player") && !bIsInside)
        {
            StopAllCoroutines();
            StartCoroutine(FadeMusic(Default, New));
            bIsInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && bIsInside)
        {
            StopAllCoroutines();
            StartCoroutine(FadeMusic(New, Default));
            bIsInside = false;
        }
    }
}
