using System.Collections;
using System.Collections.Generic;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;
using DG.Tweening;
using System;

public class PrintWall : MonoBehaviour
{
    [SerializeField] private MovementSystem _headMovementSystem;
    [SerializeField] private ParticleSystem _cementEffect;
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Transform _parent;
    [SerializeField] private float _factorPositionY;
    [SerializeField] private int _doorWallNumber;
    [SerializeField] private int _windowsWallNumber;
    [SerializeField] private int _windowsThirdLevelWallNumber;
    [SerializeField] private RoadSegment[] _roadSegments;

    private int _currentWallEnded;
    private int _currentWall;
    private float _currentPositionY;

    public event Action BuildEnded;
    public event Action DoorZoneReached;
    public event Action WindowsZoneReached;
    public event Action ThirdLevelZoneReached;

    public int CurrentWall => _currentWall;

    private void OnEnable()
    {
        foreach(RoadSegment roadSegment in _roadSegments)
            roadSegment.AutoMoveForward = false;

        _currentWallEnded = 0;
        _currentWall = 1;
        _currentPositionY = _spawnPoint.transform.position.y;

        _headMovementSystem.PathEnded += OnRoadEnd;
    }

    private void OnDisable()
    {
        _headMovementSystem.PathEnded -= OnRoadEnd;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (RoadSegment roadSegment in _roadSegments)
                roadSegment.AutoMoveForward = true;

            if (_currentWall < 13)
            {
                var wall = Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _parent);

            }
            else if(_currentWall == 13)
            {
                _cementEffect.gameObject.SetActive(false);
                _headMovementSystem.enabled = false;
                BuildEnded?.Invoke();
            }

            if(_currentWallEnded == 4)
            {
                _spawnPoint.transform.DOLocalMoveY(_currentPositionY += _factorPositionY, 0.01f);
                _currentWallEnded = 0;
                _factorPositionY = 4.5f;
            }

            _cementEffect.Play();
        }
        else
            _cementEffect.Stop();

        CheckZone();
    }

    public void CheckZone()
    {
        if (_currentWall == _doorWallNumber)
            DoorZoneReached?.Invoke();

        if (_currentWall == _windowsWallNumber)
            WindowsZoneReached?.Invoke();

        if (_currentWall == _windowsThirdLevelWallNumber)
            ThirdLevelZoneReached?.Invoke();
    }

    private void OnRoadEnd(RoadSegment roadSegment)
    {
        _currentWallEnded++;
        _currentWall++;
    }
}