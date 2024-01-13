using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private TMP_Text _scoreText;

    private int _score = 0;
    private int _numObjectives = 0;

    private Objective[] _objectives;

    public bool isPlaying { get; private set; } = false;

    public int score => _score;
    public int objectives => _numObjectives;

    private void Start()
    {
        _objectives = FindObjectsOfType<Objective>();
        _numObjectives = _objectives.Length;
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = $"Pouches found: {score}/{objectives}";
        if (_score == _numObjectives)
        {
            GameOver(true);
        }
    }

    private void GameOver(bool win = false)
    {
        _gameOverScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
    }

    public void Reset()
    {
        _gameOverScreen.SetActive(false);
        _menuScreen.SetActive(true);
        _scoreText.gameObject.SetActive(false);
        isPlaying = false;
        FindObjectOfType<Player>().transform.position = Vector3.zero;
    }

    public void Play()
    {
        _score = 0;
        isPlaying = true;
        _menuScreen.SetActive(false);
        _scoreText.gameObject.SetActive(true);
        _scoreText.text = $"Pouches found: {score}/{objectives}";
        foreach (var item in _objectives)
        {
            item.gameObject.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
