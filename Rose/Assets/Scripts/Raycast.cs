using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial_ReleaseBlue;
    [SerializeField] Material highlightMaterial_ReleaseOrange;
    [SerializeField] Material highlightMaterial_ReleasePurple;
    [SerializeField] Material defaultMaterial_BaseBlue;
    [SerializeField] Material defaultMaterial_BaseOrange;
    [SerializeField] Material defaultMaterial_BasePurple;


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

    public GameObject chargeMenu;
    public GameObject marcGalvez;
    public GameObject lluisMoreu;

    public GameObject MenuButton;
    public GameObject GalvezButton;
    public GameObject MoreuButton;

    public GameObject BaseBlue;
    public GameObject BaseOrange;
    public GameObject BasePurple;

    public GameObject InsertDisk;

    Vector3 sizeUp_Menu;
    Vector3 sizeUp_Linkedin;    
    Vector3 sizeNormal_Menu;
    Vector3 sizeNormal_Linkedin;

    Vector3 sizeUp_BaseBlue;
    Vector3 sizeUp_BaseOrange;
    Vector3 sizeUp_BasePurple;
    Vector3 sizeNormal_BaseBlue;
    Vector3 sizeNormal_BaseOrange;
    Vector3 sizeNormal_BasePurple;

    ChargeMenu trailMenu;
    ChargeMenu trailGalvez;
    ChargeMenu trailMoreu;

    bool was_blue = false;
    bool was_orange = false;
    bool was_purple = false;


    int layerMask = 1 << 8; //Number 8: Selectable

    float time_start_pressed = 0;
    float time_galvez_pressed = 0;
    float time_moreu_pressed = 0;

    void Start()
    {
        LevelScene.SetActive(false);
        trailMenu = chargeMenu.GetComponent<ChargeMenu>();
        trailGalvez = marcGalvez.GetComponent<ChargeMenu>();
        trailMoreu = lluisMoreu.GetComponent<ChargeMenu>();

        
        sizeNormal_Menu = MenuButton.transform.localScale;
        sizeNormal_Linkedin = GalvezButton.transform.localScale;
        sizeUp_Menu = sizeNormal_Menu * 1.1f;
        sizeUp_Linkedin = sizeNormal_Linkedin * 1.1f;


        sizeNormal_BaseBlue = BaseBlue.transform.localScale;
        sizeUp_BaseBlue = sizeNormal_BaseBlue * 1.1f;
    }

    void Update()
    {
        
        if(_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            _selection = null;

            if(was_blue)
            {
                selectionRenderer.material = defaultMaterial_BaseBlue;
                was_blue = false;
            }
            if(was_orange)
            {
                selectionRenderer.material = defaultMaterial_BaseOrange;
                was_orange = false;
            }
            if(was_purple)
            {
                selectionRenderer.material = defaultMaterial_BasePurple;
                was_purple = false;
            }
        }

        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {

            Transform selection = hit.transform;
            if ((selection.CompareTag(selectableGreenTag) || selection.CompareTag(selectableBlueTag) || selection.CompareTag(selectableRedTag))/* && time_pressed <= 0.5f*/)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
               
                _selection = selection;

                if (selection.CompareTag(selectableGreenTag))
                {
                    color_selected = color_green;
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial_ReleaseOrange;
                        was_orange = true;
                    }
                    

                }
                if (selection.CompareTag(selectableBlueTag))
                {
                    color_selected = color_blue;
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial_ReleaseBlue;
                        was_blue = true;
                    }

                }
                if (selection.CompareTag(selectableRedTag))
                {
                    color_selected = color_red;

                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial_ReleasePurple;
                        was_purple = true;
                    }
                   
                    
                }
            }
            // Main Menu
            else if ((selection.CompareTag(selectableStartTag) || selection.CompareTag(selectableGalvezTag) || selection.CompareTag(selectableMoreuTag)))
            {
                if (selection.CompareTag(selectableStartTag))
                {
                    // Particle effect
                    time_start_pressed += Time.deltaTime;
                    trailMenu._degree += 360 / 2 * Time.deltaTime;
                    if (time_start_pressed >= 2f)
                    {
                        time_start_pressed = 0;
                        LevelScene.SetActive(true);
                        StartScene.SetActive(false);
                        InsertDisk.SetActive(false);
                    }
                    // Size up
                    MenuButton.transform.localScale = sizeUp_Menu;
                }
                else if (selection.CompareTag(selectableGalvezTag))
                {
                    // Particle effect
                    time_galvez_pressed += Time.deltaTime;
                    trailGalvez._degree += 360 / 2 * Time.deltaTime;
                    if (time_galvez_pressed >= 2f)
                    {
                        time_galvez_pressed = 0;
                        Application.OpenURL("https://www.linkedin.com/in/marc-g%C3%A1lvez-llorens-539938173/");
                    }
                    // Size up
                    GalvezButton.transform.localScale = sizeUp_Linkedin;
                }
                else if (selection.CompareTag(selectableMoreuTag))
                {
                    // Particle effect
                    time_moreu_pressed += Time.deltaTime;
                    trailMoreu._degree += 360 / 2 * Time.deltaTime;
                    if (time_moreu_pressed >= 2f)
                    {
                        time_moreu_pressed = 0;
                        Application.OpenURL("https://www.linkedin.com/in/llu%C3%ADs-moreu-farran/");
                    }
                    // Size up
                    MoreuButton.transform.localScale = sizeUp_Linkedin;
                }
            }
            else
            {
                ResetButtons();
            }
        }
        else
        {
            ResetButtons();
        }

    }

    public string ReturnSelected()
    {
        if (color_selected != color_empty)
            return color_selected;
        else
            return color_empty;   
    }

    void ResetButtons()
    {
        color_selected = color_empty;
        time_start_pressed = 0;
        time_moreu_pressed = 0;
        time_galvez_pressed = 0;

        trailMenu.reset = true;
        trailGalvez.reset = true;
        trailMoreu.reset = true;

        MenuButton.transform.localScale = sizeNormal_Menu;
        GalvezButton.transform.localScale = sizeNormal_Linkedin;
        MoreuButton.transform.localScale = sizeNormal_Linkedin;

        BaseBlue.transform.localScale = sizeNormal_BaseBlue;
        BaseOrange.transform.localScale = sizeNormal_BaseOrange;
        BasePurple.transform.localScale = sizeNormal_BasePurple;


    }

}
