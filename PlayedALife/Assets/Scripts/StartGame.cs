using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Camera camera;
    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;

    Transform _selection;

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

        if (_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            time_pressed += Time.deltaTime;
            Transform selection = hit.transform;
            if ((selection.CompareTag(selectableStartTag) || selection.CompareTag(selectableGalvezTag) || selection.CompareTag(selectableMoreuTag)))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;

                if(time_pressed >= 2f)
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
                time_pressed = 0;
            }
        }
        else
        {
            time_pressed = 0;
        }

    }



}
