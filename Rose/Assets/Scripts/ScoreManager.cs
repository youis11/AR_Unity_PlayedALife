using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject BlueNote;
    public GameObject PurpleNote;
    public GameObject OrangeNote;

    public AudioSource audio_source;
    public AudioClip lose_streak;

    void Start()
    {
        audio_source.clip = lose_streak;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == BlueNote.tag)
        {
            Destroy(other.gameObject);
            UI.streak_combo = 0;
            audio_source.Play();

        }
        if (other.tag == PurpleNote.tag)
        {
            Destroy(other.gameObject);
            UI.streak_combo = 0;
            audio_source.Play();
        }
        if (other.tag == OrangeNote.tag)
        {
            Destroy(other.gameObject);
            UI.streak_combo = 0;
            audio_source.Play();
        }
    }
}
