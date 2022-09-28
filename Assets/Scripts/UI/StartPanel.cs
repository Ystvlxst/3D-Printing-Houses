using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            _startPanel.SetActive(false);
    }
}
