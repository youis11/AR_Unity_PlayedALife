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
            nextTargetPosition = BlueBase.transform.position;
            actualTarget = BlueBase.transform.tag;
        }
        else if (actualTarget == OrangeBase.transform.tag)
        {
            nextTargetPosition = PurpleBase.transform.position;
            actualTarget = PurpleBase.transform.tag;
        }

        transform.position = nextTargetPosition;
        
    }

    public void OnClickRight()
    {
        if (actualTarget == BlueBase.transform.tag)
        {
            nextTargetPosition = PurpleBase.transform.position;
            actualTarget = PurpleBase.transform.tag;
        }
        else if (actualTarget == PurpleBase.transform.tag)
        {
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
