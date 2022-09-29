using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertions : MonoBehaviour
{
    [SerializeField] private ZoneChecker _zoneChecker;
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private Insertion _door;
    [SerializeField] private Insertion[] _windows;
    [SerializeField] private Insertion[] _thirdLevelWindows;
    [SerializeField] private MeshRenderer _doorMesh;
    [SerializeField] private MeshRenderer[] _windowMeshes;
    [SerializeField] private Texture _doorTexture;
    [SerializeField] private Texture _windowTexture;

    private void OnEnable()
    {
        _zoneChecker.DoorZoneReached += OnFirstLEvelZoneReached;
        _zoneChecker.WindowsZoneReached += OnSecondZoneReached;
        _zoneChecker.ThirdLevelZoneReached += OnThirdZoneReached;
        _printWall.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _zoneChecker.DoorZoneReached -= OnFirstLEvelZoneReached;
        _zoneChecker.WindowsZoneReached -= OnSecondZoneReached;
        _zoneChecker.ThirdLevelZoneReached -= OnThirdZoneReached;
        _printWall.BuildEnded -= OnBuildEnd;
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
