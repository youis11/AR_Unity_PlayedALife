using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));
        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
        }

    }
}
