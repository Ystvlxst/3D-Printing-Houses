using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertions : MonoBehaviour
{
    [SerializeField] private PrintWall _printer;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject[] _windows;

    private void OnEnable()
    {
        _door.SetActive(false);

        foreach (var window in _windows)
            window.SetActive(false);

        _printer.DoorZoneReached += OnDoorZoneReached;
        _printer.WindowsZoneReached += OnWindowsZoneReached;
    }

    private void OnDisable()
    {
        _printer.DoorZoneReached -= OnDoorZoneReached;
        _printer.WindowsZoneReached -= OnWindowsZoneReached;
    }

    private void OnDoorZoneReached()
    {
        _door.SetActive(true);
    }

    private void OnWindowsZoneReached()
    {
        foreach (var window in _windows)
            window.SetActive(true);
    }
}
