using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    bool start = false;
    [SerializeField] float speed;
    [SerializeField] float distance_between;

    GameObject Spawner;

    void Start()
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner");  
    }

    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        transform.rotation = Spawner.transform.rotation;
        //if (transform.tag == "BlueNote")
        //{
        //    transform.position = new Vector3(Spawner.transform.position.x - distance_between, Spawner.transform.position.y, transform.position.z/* * -speed * Time.deltaTime*/);
            
        //}

        //if (transform.tag == "PurpleNote")
        //{
        //    transform.position = new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, transform.position.z/* * -speed * Time.deltaTime*/);
        //}

        //if (transform.tag == "OrangeNote")
        //{
        //    transform.position = new Vector3(Spawner.transform.position.x + distance_between, Spawner.transform.position.y, transform.position.z /** -speed * Time.deltaTime*/);
        //}


        //if (Input.GetKeyDown(KeyCode.Space))
        //    start = true;

        //if(start)
        //    transform.Translate(Vector3.forward * -speed * Time.deltaTime);

    }
}
