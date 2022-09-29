using TMPro;
using UnityEngine;

public class LevelNumberText : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private WinCanvas _winCanvas;

    private void OnEnable()
    {
        _winCanvas.NextLevel += OnLevelChanged;

        OnLevelChanged();
    }

    private void OnDisable()
    {
        _winCanvas.NextLevel -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        int counter = Singleton<LevelLoader>.Instance.SavedLevel;
        int index = 1 + counter;
        _levelNumber.text = "Level " + index;
    }
}
