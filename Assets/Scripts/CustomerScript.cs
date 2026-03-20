using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    public float moodMeter = 100;
    public enum Personalities
    {
        Chill, Normal, Angry, Karen
    }
    public enum ReceptionTasks
    {
        BookIn, BookOut, BuyRoom
    }

    public SpriteRenderer spriteRenderer;
    public Sprite[] CustomerSprites;

    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    [SerializeField] private TextMesh phrase;
    [SerializeField] private TextMesh moodMeterDisplay;

    private ReceptionTasks currentTask;
    private Personalities personality;
    public bool moodMeterDecreases;

    void Awake()
    {
        spriteRenderer.sprite = CustomerSprites[Random.Range(0, CustomerSprites.Length)];
        audioSource = GetComponent<AudioSource>();
        moodMeter -= Random.Range(0.1f, 60f);
        int index = Random.Range(0, 3);

        // Setter hvilken ting du må gjøre for kunden
        switch (index)
        {
            case 0: currentTask = ReceptionTasks.BookIn; break;
            case 1: currentTask = ReceptionTasks.BookOut; break;
            case 2: currentTask = ReceptionTasks.BuyRoom; break;
        }

        //Bestemmer hvor fort moodMeter går ned
        index = Random.Range(0, 4);
        switch (index)
        {
            case 0: personality = Personalities.Chill; break;
            case 1: personality = Personalities.Normal; break;
            case 2: personality = Personalities.Angry; break;
            case 3: personality = Personalities.Karen; break;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phrase.text = "du lukter\nfeta... ost";
    }

    // Update is called once per frame
    void Update()
    {
        moodMeterDisplay.text = moodMeter.ToString("F1");
    }

    public void playRandomVoiceLine()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }

    public void DecreaseMood(float amount)
    {
        moodMeter -= amount * Time.deltaTime;
    }

    public Personalities GetPersonality()
    {
        return personality;
    }
}
