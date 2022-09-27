using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class RootHeadMovement : MonoBehaviour
{
    [SerializeField] private MovementSystem _headMovementSystem;
    [SerializeField] private RoadSegment _roadSegment1;
    [SerializeField] private RoadSegment _roadSegment2;
    [SerializeField] private RoadSegment _roadSegment5;
    [SerializeField] private RoadSegment _roadSegment6;

    private void Start()
    {
        _roadSegment5.AutoMoveForward = false;
        _roadSegment6.AutoMoveForward = false;
    }

    private void Update()
    {
        if (_headMovementSystem.CurrentRoad == _roadSegment1 || _headMovementSystem.CurrentRoad == _roadSegment2)
        {
            _roadSegment5.AutoMoveForward = true;
            _roadSegment6.AutoMoveForward = true;
        }
        else
        {
            _roadSegment5.AutoMoveForward = false;
            _roadSegment6.AutoMoveForward = false;
        }
    }
}
