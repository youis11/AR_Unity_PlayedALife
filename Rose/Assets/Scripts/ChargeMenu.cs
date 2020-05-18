using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeMenu : MonoBehaviour
{
    public float _tangentCircleRadius;
    public float _degree;

    public GameObject _outterCircleGO, _tangentCircleGo;
    public Material matWithoutA;

    TrailRenderer trail;
    public bool reset;

    private void Start()
    {
        _outterCircleGO.GetComponent<Renderer>().material = matWithoutA;
        _tangentCircleGo.GetComponent<Renderer>().material = matWithoutA;
        trail = _tangentCircleGo.GetComponent<TrailRenderer>();
        trail.enabled = false; 
    }
    void Update()
    {
        _tangentCircleGo.transform.position = GetRotatedTangent(_degree, _tangentCircleRadius) + _outterCircleGO.transform.position;
        trail.enabled = true;

        if (reset)
        {
            trail.enabled = false;
            trail.Clear();
            _degree = 0;
            reset = false;
        }
    }

    protected Vector3 GetRotatedTangent(float degree, float scale)
    {
        double angle = degree * Mathf.Deg2Rad;
        float x = scale * (float)System.Math.Sin(angle);
        float z = scale * (float)System.Math.Cos(angle);
        return new Vector3(x, 0, z);
    }
}
