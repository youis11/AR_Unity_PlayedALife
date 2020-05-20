using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject BlueBase;
    public GameObject PurpleBase;
    public GameObject OrangeBase;

    public GameObject BlueNote;
    public GameObject PurpleNote;
    public GameObject OrangeNote;

    public AudioSource audio_source;
    public AudioClip release_wav;
    public AudioClip move_wav;

    



    Vector3 nextTargetPosition;
    string actualTarget;

    void Start()
    {
        actualTarget = PurpleBase.transform.tag;
    }

    void Update()
    {
        
    }

    public void OnClickLeft()
    {
        if(actualTarget == BlueBase.transform.tag)
        {
            nextTargetPosition = BlueBase.transform.position;
            actualTarget = BlueBase.transform.tag;
        }
        else if (actualTarget == PurpleBase.transform.tag)
        {
            audio_source.clip = move_wav;
            audio_source.Play();
            nextTargetPosition = BlueBase.transform.position;
            actualTarget = BlueBase.transform.tag;
        }
        else if (actualTarget == OrangeBase.transform.tag)
        {
            audio_source.clip = move_wav;
            audio_source.Play();
            nextTargetPosition = PurpleBase.transform.position;
            actualTarget = PurpleBase.transform.tag;
        }

        
        transform.position = nextTargetPosition;
        
    }

    public void OnStartSong()
    {
        actualTarget = PurpleBase.transform.tag;
        nextTargetPosition = PurpleBase.transform.position;
        transform.position = nextTargetPosition;
    }

    public void OnClickRight()
    {
        if (actualTarget == BlueBase.transform.tag)
        {
            audio_source.clip = move_wav;
            audio_source.Play();
            nextTargetPosition = PurpleBase.transform.position;
            actualTarget = PurpleBase.transform.tag;
        }
        else if (actualTarget == PurpleBase.transform.tag)
        {
            audio_source.clip = move_wav;
            audio_source.Play();
            nextTargetPosition = OrangeBase.transform.position;
            actualTarget = OrangeBase.transform.tag;
        }
        else if (actualTarget == OrangeBase.transform.tag)
        {
            nextTargetPosition = OrangeBase.transform.position;
            actualTarget = OrangeBase.transform.tag;
        }

      
        transform.position = nextTargetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == BlueNote.tag)
        {
            UI.score_value += 10;
            UI.streak_combo ++;
            UI.score_value += UI.streak_combo;

            audio_source.clip = release_wav;
            audio_source.Play();
            Destroy(other.gameObject);
        }
        if (other.tag == PurpleNote.tag)
        {
            UI.score_value += 10;
            UI.streak_combo++;
            UI.score_value += UI.streak_combo;

            audio_source.clip = release_wav;
            audio_source.Play();
            Destroy(other.gameObject);
        }
        if (other.tag == OrangeNote.tag)
        {
            UI.score_value += 10;
            UI.streak_combo++;
            UI.score_value += UI.streak_combo;

            audio_source.clip = release_wav;
            audio_source.Play();
            Destroy(other.gameObject);
        }
    }

   
}
