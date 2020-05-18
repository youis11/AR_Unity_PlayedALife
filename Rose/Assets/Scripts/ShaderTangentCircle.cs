using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTangentCircle : Shader_CircleTangent
{
    public GameObject _circlePrefab, _circleTargetPrefab;
    public GameObject _innerCircleGO, _outterCircleGO, _tangentCircleGo;
    public Vector4 _innerCircle, _outterCircle;
    public float _tangentCircleRadius;
    public float _degree;

    // Start is called before the first frame update
    void Start()
    {
        
        _innerCircleGO = (GameObject)Instantiate(_circlePrefab, transform.position, transform.rotation, transform);

        _outterCircleGO = (GameObject)Instantiate(_circlePrefab, transform.position, transform.rotation, transform);

        _tangentCircleGo = (GameObject)Instantiate(_circleTargetPrefab, transform.position, transform.rotation, transform);

    }

    // Update is called once per frame
    void Update()
    {
        _innerCircleGO.transform.position = new Vector3(_innerCircle.x, _innerCircle.y, _innerCircle.z);
        _innerCircleGO.transform.localScale = new Vector3(_innerCircle.w, _innerCircle.w, _innerCircle.w) * 2;

        _outterCircleGO.transform.position = new Vector3(_outterCircle.x, _outterCircle.y, _outterCircle.z);
        _outterCircleGO.transform.localScale = new Vector3(_outterCircle.w, _outterCircle.w, _outterCircle.w) * 2;

        _tangentCircleGo.transform.position = GetRotatedTangent(_degree, _outterCircle.w) + _outterCircleGO.transform.position;
        _tangentCircleGo.transform.localScale = new Vector3(_tangentCircleRadius, _tangentCircleRadius, _tangentCircleRadius) * 2;
    }
}
