using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI gText;
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button applyButton;
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle toggle;
    [Header("Sounds")]
    [SerializeField] private AudioMixer mixer;

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
        gText.text = $"Вы убили {gun.enemyScore -1} врагов, но все равно проиграли...";
    }
    private void Restart()
    {
        gun.player.transform.position = gun.playerPos.transform.position;
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
        float volume = slider.value;
        mixer.SetFloat("masterSound", Mathf.Log10(volume) * 20);

        if (!toggle.isOn)
            mixer.SetFloat("Bg", -80f);
        else
            mixer.SetFloat("Bg", Mathf.Log10(volume) * 20);
    }
}
