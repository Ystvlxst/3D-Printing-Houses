using System.Collections;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private float _speedRate;
    [SerializeField] private GameObject _map;


    private float _speed;

    private void OnEnable()
    {
        _speed = 0;
        _printWall.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuildEnd;
    }

    private void Update()
    {
        _map.transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }

    private void OnBuildEnd()
    {
        StartCoroutine(StartCamera());
    }

    private IEnumerator StartCamera()
    {
        yield return new WaitForSeconds(1f);
        _speed = _speedRate;
    }
}
