using System.Collections;
using System.Collections.Generic;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;
using DG.Tweening;

public class PrintWall : MonoBehaviour
{
    [SerializeField] private MovementSystem _headMovementSystem;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private ParticleSystem _cementEffect;
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Transform _parent;
    [SerializeField] private RoadSegment _roadSegment4;
    [SerializeField] private float _factorPositionY;

    private int _currentWallEnded;
    private float _currentPositionY;

    private void OnEnable()
    {
        _currentWallEnded = 0;
        _currentPositionY = _spawnPoint.transform.position.y;
        _headMovementSystem.PathEnded += OnRoadEnd;
    }

    private void OnDisable()
    {
        _headMovementSystem.PathEnded -= OnRoadEnd;
    }

    private void Update()
    {
        if (_mouseInput.IsMoved)
        {
            var wall = Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _parent);

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
    }

    private void OnRoadEnd(RoadSegment roadSegment) =>
        _currentWallEnded++;
}