using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseNote : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] string noteTag;
    //public GameObject selectionManager;

    [SerializeField] Material highlightMaterial_ReleaseBlue;
    [SerializeField] Material highlightMaterial_ReleaseOrange;
    [SerializeField] Material highlightMaterial_ReleasePurple;
    [SerializeField] Material defaultMaterial_BaseBlue;
    [SerializeField] Material defaultMaterial_BaseOrange;
    [SerializeField] Material defaultMaterial_BasePurple;

    Renderer releaserRenderer;
    void Start()
    {
        releaserRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag && other.tag == noteTag)
        {
            // TODO: White particles going up with trail and score++ and destroy note


        }
        if (other.tag == playerTag)
        {
            ActiveReleasers();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == playerTag)
        {
            RestartReleasers();
        }
        
    }

    void RestartReleasers()
    {
        if (transform.tag == "Orange_Releaser")
        {
            releaserRenderer.material = defaultMaterial_BaseOrange;
        }
        if (transform.tag == "Purple_Releaser")
        {
            releaserRenderer.material = defaultMaterial_BasePurple;
        }
        if (transform.tag == "Blue_Releaser")
        {
            releaserRenderer.material = defaultMaterial_BaseBlue;
        }

    }
    void ActiveReleasers()
    {
        if (transform.tag == "Orange_Releaser")
        {
            releaserRenderer.material = highlightMaterial_ReleaseOrange;
        }
        if (transform.tag == "Purple_Releaser")
        {
            releaserRenderer.material = highlightMaterial_ReleasePurple;
        }
        if (transform.tag == "Blue_Releaser")
        {
            releaserRenderer.material = highlightMaterial_ReleaseBlue;
        }

    }

}
