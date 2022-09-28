using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertions : MonoBehaviour
{
    [SerializeField] private PrintWall _printer;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject[] _windows;
    [SerializeField] private MeshRenderer _doorMesh;
    [SerializeField] private MeshRenderer[] _windowMeshes;
    [SerializeField] private Texture _doorTexture;
    [SerializeField] private Texture _windowTexture;
    [SerializeField] private Insertion[] _insertions;

    public float AllPoints { get; private set; }

    private void OnEnable()
    {
        _door.SetActive(false);

        foreach (var window in _windows)
            window.SetActive(false);

        _printer.DoorZoneReached += OnDoorZoneReached;
        _printer.WindowsZoneReached += OnWindowsZoneReached;
        _printer.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printer.DoorZoneReached -= OnDoorZoneReached;
        _printer.WindowsZoneReached -= OnWindowsZoneReached;
        _printer.BuildEnded -= OnBuildEnd;
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

    private void OnBuildEnd()
    {
        _doorMesh.material.mainTexture = _doorTexture;
        _doorMesh.material.color = Color.white;

        foreach(var mesh in _windowMeshes)
        {
            mesh.material.mainTexture = _windowTexture;
            mesh.material.color = Color.white;
        }

        foreach (var insertion in _insertions)
            AllPoints += insertion.Point;
    }
}
