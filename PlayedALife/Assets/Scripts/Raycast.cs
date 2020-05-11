using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;


    [SerializeField] Material StartMaterial;
    [SerializeField] Material GalvezMaterial;
    [SerializeField] Material MoreutMaterial;
    [SerializeField] Material StartMaterialSelected;
    [SerializeField] Material GalvezMaterialSelected;
    [SerializeField] Material MoreutMaterialSelected;

    Transform _selection;

    [SerializeField] string selectableGreenTag;
    [SerializeField] string selectableRedTag;
    [SerializeField] string selectableBlueTag;

    string color_selected;
    string color_green = "Green";
    string color_blue = "Blue";
    string color_red = "Red";
    string color_empty = "Empty";

    [SerializeField] string selectableStartTag;
    [SerializeField] string selectableGalvezTag;
    [SerializeField] string selectableMoreuTag;

    public GameObject StartScene;
    public GameObject LevelScene;

    int layerMask = 1 << 8; //Number 8: Selectable

    float time_pressed = 0;

    void Start()
    {
        LevelScene.SetActive(false);
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
            if ((selection.CompareTag(selectableGreenTag) || selection.CompareTag(selectableBlueTag) || selection.CompareTag(selectableRedTag))/* && time_pressed <= 0.5f*/)
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
            }
            // Main Menu
            else if ((selection.CompareTag(selectableStartTag) || selection.CompareTag(selectableGalvezTag) || selection.CompareTag(selectableMoreuTag)))
            {
                time_pressed += Time.deltaTime;
                //var selectionRendererer = selection.GetComponent<Renderer>();
                //if (selectionRendererer != null)
                //{
                //    selectionRendererer.material = highlightMaterial;
                //}
                //_selection = selection;

                if (time_pressed >= 2f)
                {
                    time_pressed = 0;
                    if (selection.CompareTag(selectableStartTag))
                    {
                        LevelScene.SetActive(true);
                        StartScene.SetActive(false);

                    }
                    if (selection.CompareTag(selectableGalvezTag))
                        Application.OpenURL("https://www.linkedin.com/in/marc-g%C3%A1lvez-llorens-539938173/");
                    if (selection.CompareTag(selectableMoreuTag))
                        Application.OpenURL("https://www.linkedin.com/in/llu%C3%ADs-moreu-farran/");
                }
            }
            else
            {
                color_selected = color_empty;
            }
        }
        else
        {
            color_selected = color_empty;
            time_pressed = 0;
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
