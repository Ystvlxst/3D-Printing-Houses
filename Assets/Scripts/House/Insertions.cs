using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertions : MonoBehaviour
{
    [SerializeField] private PrintWall _printer;
    [SerializeField] private Insertion _door;
    [SerializeField] private Insertion[] _windows;
    [SerializeField] private Insertion[] _thirdLevelWindows;
    [SerializeField] private MeshRenderer _doorMesh;
    [SerializeField] private MeshRenderer[] _windowMeshes;
    [SerializeField] private Texture _doorTexture;
    [SerializeField] private Texture _windowTexture;

    private void OnEnable()
    {
        _printer.DoorZoneReached += OnFirstLEvelZoneReached;
        _printer.WindowsZoneReached += OnSecondZoneReached;
        _printer.ThirdLevelZoneReached += OnThirdZoneReached;
        _printer.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printer.DoorZoneReached -= OnFirstLEvelZoneReached;
        _printer.WindowsZoneReached -= OnSecondZoneReached;
        _printer.ThirdLevelZoneReached -= OnThirdZoneReached;
        _printer.BuildEnded -= OnBuildEnd;
    }

    private void OnFirstLEvelZoneReached()
    {
        _door.SetScale();
    }

    private void OnSecondZoneReached()
    {
        foreach (var window in _windows)
            window.SetScale();
    }

    private void OnThirdZoneReached()
    {
        foreach (var window in _thirdLevelWindows)
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
