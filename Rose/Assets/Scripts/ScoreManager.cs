using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject BlueNote;
    public GameObject PurpleNote;
    public GameObject OrangeNote;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == BlueNote.tag)
        {
            Destroy(other.gameObject);

        }
        if (other.tag == PurpleNote.tag)
        {
            Destroy(other.gameObject);
        }
        if (other.tag == OrangeNote.tag)
        {
            Destroy(other.gameObject);
        }
    }
}
