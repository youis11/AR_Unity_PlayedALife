using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    enum Difficulty
    {
        HARD,
        MEDIUM,
        EASY,
        SUPEREZ,
        NONE
    }

    Difficulty difficultyType = Difficulty.EASY; 

    float bpm = 0.491f;
    float timer =0;
    float bpm_instantiate = 0;

    public GameObject purpleNote;
    public GameObject blueNote;
    public GameObject orangeNote;

    int random_note_number = 0;
    int last_random_note_number = 0;
    public float distance_between_notes;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            difficultyType = Difficulty.SUPEREZ;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            difficultyType = Difficulty.EASY;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            difficultyType = Difficulty.MEDIUM;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            difficultyType = Difficulty.HARD;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            difficultyType = Difficulty.NONE;

        switch (difficultyType)
        {
            case Difficulty.HARD: // BPM Real
                bpm_instantiate = bpm;
                break;
            case Difficulty.MEDIUM: // BPM *2
                bpm_instantiate = bpm *2;
                break;
            case Difficulty.EASY: // BPM *3
                bpm_instantiate = bpm * 3;
                break;
            case Difficulty.SUPEREZ: //BPM *4
                bpm_instantiate = bpm * 4;
                break;
            case Difficulty.NONE: //BPM *nvm  :)
                bpm_instantiate = bpm * 9999999999999999;
                break;
            default:
                difficultyType = Difficulty.SUPEREZ;
                break;
        }

        timer += Time.deltaTime;
        if(timer >= bpm_instantiate)
        {
            while (random_note_number == last_random_note_number)
                random_note_number = Random.Range(1, 4);

            last_random_note_number = random_note_number;

            if (last_random_note_number == 1)
                Instantiate(purpleNote, transform.position, transform.rotation, transform);

            if (last_random_note_number == 2)
                Instantiate(blueNote, new Vector3(transform.position.x - distance_between_notes, transform.position.y, transform.position.z), transform.rotation, transform);

            if (last_random_note_number == 3)
                Instantiate(orangeNote, new Vector3(transform.position.x + distance_between_notes, transform.position.y, transform.position.z), transform.rotation, transform);

            timer = 0;
        }
    }
}
