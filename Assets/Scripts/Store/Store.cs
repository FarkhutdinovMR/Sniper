using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    public void Open()
    {
        Time.timeScale = 0;
        _canvas.SetActive(true);
    }
}