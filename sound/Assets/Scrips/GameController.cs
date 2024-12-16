using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject player; 
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

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        pauseButton.onClick.AddListener(Pause);
        playButton.onClick.AddListener(Play);
        applyButton.onClick.AddListener(AudioSettings);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        endText.text = $"¬ы одолели {gun.enemyScore -1} врагов, но все равно проиграли...";
        return;
    }
    private void Restart()
    {
        player.transform.position = new Vector2(-4, 0);
        gun.enemyScore = 0;
        gun.lives = 3;
        gun.healthText.text = $"Health: {gun.lives}";
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
