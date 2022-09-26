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

        if (_headMovementSystem.CurrentRoad == _roadSegment1)
        {
            if (_mouseInput.IsMoved)
            {
                _wall1.localScale = Vector3.MoveTowards(new Vector3(_wall1.localScale.x, _wall1.localScale.y, _wall1.localScale.z),
                    new Vector3(localScaleX1 += _scaleXFactor, _wall1.localScale.y, _wall1.localScale.z), _speedScale * Time.deltaTime);
                _wall1.Translate(Vector3.right * _speedTranslate * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation1, _wall1.transform.position) > _clampPosition)
                _wall1.transform.position = lastLocation1;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment2)
        {
            if (_mouseInput.IsMoved)
            {
                _wall2.localScale = Vector3.MoveTowards(new Vector3(_wall2.localScale.x, _wall2.localScale.y, _wall2.localScale.z),
                    new Vector3(localScaleX2 += _scaleXFactor, _wall2.localScale.y, _wall2.localScale.z), _speedScale * Time.deltaTime);
                _wall2.Translate(Vector3.right * _speedTranslate * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation2, _wall2.transform.position) > _clampPosition)
                _wall2.transform.position = lastLocation2;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment3)
        {
            if (_mouseInput.IsMoved)
            {
                _wall3.localScale = Vector3.MoveTowards(new Vector3(_wall3.localScale.x, _wall3.localScale.y, _wall3.localScale.z),
                    new Vector3(localScaleX3 += _scaleXFactor, _wall3.localScale.y, _wall3.localScale.z), _speedScale * Time.deltaTime);
                _wall3.Translate(Vector3.left * _speedTranslate * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation3, _wall3.transform.position) > _clampPosition)
                _wall3.transform.position = lastLocation3;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment4)
        {
            if (_mouseInput.IsMoved)
            {
                _wall4.localScale = Vector3.MoveTowards(new Vector3(_wall4.localScale.x, _wall4.localScale.y, _wall4.localScale.z),
                    new Vector3(localScaleX4 += _scaleXFactor, _wall4.localScale.y, _wall4.localScale.z), _speedScale * Time.deltaTime);
                _wall4.Translate(Vector3.left * _speedTranslate * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation4, _wall4.transform.position) > _clampPosition)
                _wall4.transform.position = lastLocation4;
        }
    }
}
