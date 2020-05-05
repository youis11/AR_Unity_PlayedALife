using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ActiveSphere : MonoBehaviour, IVirtualButtonEventHandler
{
    VirtualButtonBehaviour Button;
    public GameObject Sphere;
    public Material green;
    Renderer S_rend;

    Material lastMat;

    // Start is called before the first frame update
    void Start()
    {
        Button = GetComponent<VirtualButtonBehaviour>();
        S_rend = Sphere.GetComponent<Renderer>();

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        lastMat = S_rend.material;
        S_rend.material = green;
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        S_rend.material = lastMat;
    }
}
