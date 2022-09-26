using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class RootHeadMovement : MonoBehaviour
{
    [SerializeField] private MovementSystem _headMovementSystem;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private RoadSegment _roadSegment1;
    [SerializeField] private RoadSegment _roadSegment2;

    private void Update()
    {
        if (_headMovementSystem.CurrentRoad == _roadSegment1 || _headMovementSystem.CurrentRoad == _roadSegment2)
            _mouseInput.enabled = true;
        else
            _mouseInput.enabled = false;
    }
}
