using System.Collections;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private CameraBlend _camera;
    [SerializeField] private PrintWall _printWall;

    private void OnEnable()
    {
        _printWall.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuildEnd;
    }

    private void OnBuildEnd()
    {
        StartCoroutine(StartCamera());
    }

    private IEnumerator StartCamera()
    {
        yield return new WaitForSeconds(1f);
        _camera.Finish();
    }
}
