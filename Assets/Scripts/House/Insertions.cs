using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Insertions : MonoBehaviour
{
    [SerializeField] private ZoneChecker _zoneChecker;
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private Insertion[] _doors;
    [SerializeField] private Insertion[] _secondLevelWindows;
    [SerializeField] private Insertion[] _thirdLevelWindows;
    [SerializeField] private MeshRenderer[] _doorsMesh;
    [SerializeField] private MeshRenderer[] _windowMeshes;
    [SerializeField] private Texture _doorTexture;
    [SerializeField] private Texture _windowTexture;

    private Coroutine _coroutine;

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
        foreach (var door in _doors)
            door.SetScale();
    }

    private void OnSecondZoneReached()
    {
        foreach (var window in _secondLevelWindows)
            window.SetScale();
    }

    private void OnThirdZoneReached()
    {
        foreach (var window in _thirdLevelWindows)
            window.SetScale();
    }

    private void OnBuildEnd()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Scaling());
    }

    private IEnumerator Scaling()
    {
        yield return new WaitForSeconds(0.25f);

        foreach (var mesh in _doorsMesh)
        {
            mesh.material.mainTexture = _doorTexture;
            mesh.material.color = Color.white;
        }

        foreach (var mesh in _windowMeshes)
        {
            mesh.material.mainTexture = _windowTexture;
            mesh.material.color = Color.white;
        }
        _coroutine = null;
    }
}
