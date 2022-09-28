using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertions : MonoBehaviour
{
    [SerializeField] private PrintWall _printer;
    [SerializeField] private Insertion _door;
    [SerializeField] private Insertion[] _windows;
    [SerializeField] private MeshRenderer _doorMesh;
    [SerializeField] private MeshRenderer[] _windowMeshes;
    [SerializeField] private Texture _doorTexture;
    [SerializeField] private Texture _windowTexture;

    private void OnEnable()
    {
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
        _door.SetScale();
    }

    private void OnWindowsZoneReached()
    {
        foreach (var window in _windows)
            window.SetScale();
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
    }
}
