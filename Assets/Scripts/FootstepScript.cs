using UnityEngine;

// IKKE rør vær så snill -fra emil

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class FootstepScript : MonoBehaviour
{   
    public AudioClip[] footstepClips;

    public float minSpeedThreshold = 0.5f;

    public float stepIntervalAtFullSpeed = 0.35f;

    public float fullSpeed = 5f;

    [Range(0f, 1f)]
    public float volume = 0.7f;

    public bool randomisePitch = true;
    public float pitchMin = 0.9f;
    public float pitchMax = 1.1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private float stepTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // flat lyd
    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        if (speed < minSpeedThreshold)
        {
            // reset timer når man står still
            stepTimer = 0f;
            return;
        }

        // skalerings ting
        float t = Mathf.Clamp01(speed / fullSpeed);
        float interval = Mathf.Lerp(stepIntervalAtFullSpeed * 1.5f, stepIntervalAtFullSpeed, t);

        stepTimer -= Time.deltaTime;
        if (stepTimer <= 0f)
        {
            PlayFootstep();
            stepTimer = interval;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips == null || footstepClips.Length == 0) return;

        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
        if (clip == null) return;

        if (randomisePitch)
            audioSource.pitch = Random.Range(pitchMin, pitchMax);
        else
            audioSource.pitch = 1f;

        audioSource.PlayOneShot(clip, volume);
    }
}
