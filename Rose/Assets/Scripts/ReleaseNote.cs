using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseNote : MonoBehaviour
{
    [SerializeField] string notetag;
    Raycast rayScript;
    public GameObject selectionManager;
    // Start is called before the first frame update
    void Start()
    {
        rayScript = selectionManager.GetComponent<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == notetag && rayScript.ReturnSelected() == notetag)
        {
            Debug.Log("Point+1");
            other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.75f);
        }
        
    }

    
}
