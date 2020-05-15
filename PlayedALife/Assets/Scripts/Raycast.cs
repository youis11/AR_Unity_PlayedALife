using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial_ReleaseBlue;
    [SerializeField] Material highlightMaterial_ReleasePrange;
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

    Vector3 sizeUp_Menu;
    Vector3 sizeUp_Linkedin;    
    Vector3 sizeNormal_Menu;
    Vector3 sizeNormal_Linkedin;

    ChargeMenu trailMenu;
    ChargeMenu trailGalvez;
    ChargeMenu trailMoreu;


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
    }

    void Update()
    {
        
        if(_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial_BaseBlue;
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
                    selectionRenderer.material = highlightMaterial_ReleaseBlue;
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
    }

}
