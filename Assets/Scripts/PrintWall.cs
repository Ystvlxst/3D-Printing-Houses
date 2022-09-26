using System.Collections;
using System.Collections.Generic;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class PrintWall : MonoBehaviour
{
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

        if (_mouseInput.IsMoved)
            _cementEffect.Play();
        else
            _cementEffect.Stop();

        if (_headMovementSystem.CurrentRoad == _roadSegment1)
        {
            if (_mouseInput.IsMoved)
            {
                _wall1.localScale = Vector3.MoveTowards(_wall1.localScale, _wall1.localScale *= 1.2f, Time.deltaTime);
                _wall1.Translate(Vector3.right * Time.deltaTime);
            }

            if (Vector3.Distance(_startLocation1, _wall1.transform.position) > _clampPosition)
                _wall1.transform.position = lastLocation1;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment2)
        {
            if (_mouseInput.IsMoved)
                _wall2.Translate(Vector3.up * Time.deltaTime);

            if (Vector3.Distance(_startLocation2, _wall2.transform.position) > _clampPosition)
                _wall2.transform.position = lastLocation2;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment3)
        {
            if (_mouseInput.IsMoved)
                _wall3.Translate(Vector3.up * Time.deltaTime);

            if (Vector3.Distance(_startLocation3, _wall3.transform.position) > _clampPosition)
                _wall3.transform.position = lastLocation3;
        }

        if (_headMovementSystem.CurrentRoad == _roadSegment4)
        {
            if (_mouseInput.IsMoved)
                _wall4.Translate(Vector3.up * Time.deltaTime);

            if (Vector3.Distance(_startLocation4, _wall4.transform.position) > _clampPosition)
                _wall4.transform.position = lastLocation4;
        }
    }
}
