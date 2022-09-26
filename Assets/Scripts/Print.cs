using System.Collections;
using System.Collections.Generic;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class Print : MonoBehaviour
{
    [SerializeField] private float _scaleXFactor;
    [SerializeField] private float _speedTranslate;
    [SerializeField] private float _speedScale;
    [SerializeField] private MovementSystem _headMovementSystem;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private ParticleSystem _cementEffect;
    [SerializeField] private Transform _wall1;
    [SerializeField] private Transform _wall2;
    [SerializeField] private Transform _wall3;
    [SerializeField] private Transform _wall4;
    [SerializeField] private RoadSegment _roadSegment1;
    [SerializeField] private RoadSegment _roadSegment2;
    [SerializeField] private RoadSegment _roadSegment3;
    [SerializeField] private RoadSegment _roadSegment4;

    private float _clampPosition = 5f;
    private Vector3 _startLocation1;
    private Vector3 _startLocation2;
    private Vector3 _startLocation3;
    private Vector3 _startLocation4;

    private void Start()
    {
        _startLocation1 = _wall1.transform.position;
        _startLocation2 = _wall2.transform.position;
        _startLocation3 = _wall3.transform.position;
        _startLocation4 = _wall4.transform.position;
    }

    private void Update()
    {
        Vector3 lastLocation1 = _wall1.transform.position;
        Vector3 lastLocation2 = _wall2.transform.position;
        Vector3 lastLocation3 = _wall3.transform.position;
        Vector3 lastLocation4 = _wall4.transform.position;

        float localScaleX1 = _wall1.localScale.x;
        float localScaleX2 = _wall2.localScale.x;
        float localScaleX3 = _wall3.localScale.x;
        float localScaleX4 = _wall4.localScale.x;

        if (_mouseInput.IsMoved)
            _cementEffect.Play();
        else
            _cementEffect.Stop();

        Wall(_roadSegment1, _wall1, localScaleX1, Vector3.right, lastLocation1);
        Wall(_roadSegment2, _wall2, localScaleX2, Vector3.right, lastLocation2);
        Wall(_roadSegment3, _wall3, localScaleX3, Vector3.left, lastLocation3);
        Wall(_roadSegment4, _wall4, localScaleX4, Vector3.left, lastLocation4);
    }

    private void Wall(RoadSegment roadSegment, Transform wall, float localScaleX, Vector3 dierection, Vector3 lastLocation)
    {
        if (_headMovementSystem.CurrentRoad == roadSegment)
        {
            if (_mouseInput.IsMoved)
            {
                wall.localScale = Vector3.MoveTowards(new Vector3(wall.localScale.x, wall.localScale.y, wall.localScale.z),
                    new Vector3(localScaleX += _scaleXFactor, wall.localScale.y, wall.localScale.z), _speedScale * Time.deltaTime);
                wall.Translate(dierection * _speedTranslate * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation1, wall.transform.position) > _clampPosition)
                wall.transform.position = lastLocation;
        }
    }
}
