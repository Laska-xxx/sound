using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI endText;
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button applyButton;
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle toggle;
    [Header("Sounds")]
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource panchSource;
    [SerializeField] private AudioSource panchEnemySource;
    [SerializeField] private AudioSource shootSource;
    private int gunLives;
    private int enemyScore;
    private TextMeshProUGUI gunText;

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        pauseButton.onClick.AddListener(Pause);
        playButton.onClick.AddListener(Play);
        applyButton.onClick.AddListener(AudioSettings);
    }

    public void GameOver(int lives, TextMeshProUGUI text, int score)
    {
        gunLives = lives;
        gunText = text;
        enemyScore = score;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        endText.text = $"¬ы одолели {enemyScore} врагов, но все равно проиграли...";
        return;
    }
    private void Restart()
    {
        enemyScore = 0;
        gunLives = 3;
        gunText.text = $"Health: {gunLives}";
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    private void Play()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    private void AudioSettings()
    {
        bgMusic.mute = toggle.enabled;
        bgMusic.volume = slider.value;
        panchSource.volume = slider.value;
        panchEnemySource.volume = slider.value;
        shootSource.volume = slider.value;
    }
}
