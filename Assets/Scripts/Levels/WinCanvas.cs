using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    [SerializeField] private Button _restartLevel;
    [SerializeField] private Button _nextLevel;

    public event Action NextLevel;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnNextLevelButtonClicked);
        _restartLevel.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnNextLevelButtonClicked);
        _restartLevel.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void OnNextLevelButtonClicked()
    {
        Singleton<LevelLoader>.Instance.LoadNextLevel();
        NextLevel?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        Singleton<LevelLoader>.Instance.ReloadCurrentLevel();
    }
}
