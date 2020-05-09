using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;

    Transform _selection;

    [SerializeField] string selectableGreenTag;
    [SerializeField] string selectableRedTag;
    [SerializeField] string selectableBlueTag;

    string color_selected;
    string color_green = "Green";
    string color_blue = "Blue";
    string color_red = "Red";
    string color_empty = "Empty";


    int layerMask = 1 << 8; //Number 8: Selectable

    float time_pressed = 0;

    void Start()
    {
    }

    void Update()
    {
        
        if(_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {

            Transform selection = hit.transform;
            if((selection.CompareTag(selectableGreenTag) || selection.CompareTag(selectableBlueTag) || selection.CompareTag(selectableRedTag))/* && time_pressed <= 0.5f*/)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

                if (selection.CompareTag(selectableGreenTag))
                    color_selected = color_green;
                if (selection.CompareTag(selectableBlueTag))
                    color_selected = color_blue;
                if (selection.CompareTag(selectableRedTag))
                    color_selected = color_red;

                //time_pressed += Time.deltaTime;
            }
            else
            {
                color_selected = color_empty;
            }
        }
        else
        {
            color_selected = color_empty;
            //time_pressed = 0;
        }

    }

    public string ReturnSelected()
    {
        if (color_selected != color_empty)
            return color_selected;
        else
            return color_empty;   
    }

}
