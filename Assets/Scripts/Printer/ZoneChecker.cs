using System;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private int _doorWallNumber;
    [SerializeField] private int _windowsWallNumber;
    [SerializeField] private int _windowsThirdLevelWallNumber;

    public event Action DoorZoneReached;
    public event Action WindowsZoneReached;
    public event Action ThirdLevelZoneReached;

    private void FixedUpdate()
    {
        CheckZone();
    }

    public void CheckZone()
    {
        if (_printWall.CurrentWall == _doorWallNumber)
            DoorZoneReached?.Invoke();

        if (_printWall.CurrentWall == _windowsWallNumber)
            WindowsZoneReached?.Invoke();

        if (_printWall.CurrentWall == _windowsThirdLevelWallNumber)
            ThirdLevelZoneReached?.Invoke();
    }
}
