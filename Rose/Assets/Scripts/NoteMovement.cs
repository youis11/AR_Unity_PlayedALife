using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    bool start = false;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.Space))
        //    start = true;
        
        //if(start)
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

    }
}
