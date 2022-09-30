using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class LevelAnalytics : MonoBehaviour
{
    [SerializeField] private WinCanvas _winCanvas;
    [SerializeField] private PrintWall _printWall;

    private Analytics _analytics;
    private int _levelNumber;
    private float _startTime;

    private void Awake()
    {
        _analytics = Singleton<Analytics>.Instance;
        _levelNumber = Singleton<LevelLoader>.Instance.SavedLevel;
    }

    private void OnEnable()
    {
        _printWall.BuildEnded += OnBuildEnded;
        _winCanvas.NextLevel += OnLevelCompleted;
        _winCanvas.RestartLevel += OnReloading;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuildEnded;
        _winCanvas.NextLevel -= OnLevelCompleted;
        _winCanvas.RestartLevel -= OnReloading;
    }

    private void Start()
    {
        _analytics.FireEvent("main_menu");
    }

    private void OnBuildEnded()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("building_complete", parameters);
    }

    private void OnLevelCompleted()
    {
        var timeSpent = Time.realtimeSinceStartup - _startTime;
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
            { "time_spent", (int)timeSpent },
        };

        _analytics.FireEvent("level_complete", parameters);
        _analytics.ForceSendEventBuffer();
    }

    private void OnReloading()
    {
        var parameters = new Dictionary<string, object>() {
            { "level", _levelNumber },
        };

        _analytics.FireEvent("level_restart", parameters);
    }
}
