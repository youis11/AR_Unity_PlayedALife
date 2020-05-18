using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseNote : MonoBehaviour
{
    [SerializeField] string player;
    [SerializeField] string noteTag;
    public GameObject selectionManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == player && other.tag == noteTag)
        {
            // TODO: White particles going up with trail and score++
        }
        if (other.tag == player)
        {
            // TODO change material 
        }
        
    }

    
}
