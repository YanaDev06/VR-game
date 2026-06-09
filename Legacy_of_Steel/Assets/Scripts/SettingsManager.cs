using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;

    [Header("UI Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider brightnessSlider;

    [Header("Post-Processing")]
    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;

    private const string PREF_MUSIC = "MusicVol";
    private const string PREF_SFX = "SFXVol";
    private const string PREF_BRIGHTNESS = "Brightness";

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGet(out colorAdjustments);
        }

        if (audioMixer == null)
        {
            Debug.LogError("❌ Audio Mixer НЕ назначен в инспекторе!");
            return;
        }

        Debug.Log("✅ Audio Mixer назначен");
        LoadSettings();
    }

    public void SetMusicVolume(float value)
    {
        if (audioMixer == null) return;

        float dB = value > 0.001f ? Mathf.Log10(value) * 20f : -80f;

        // Пробуем разные варианты названий
        bool success = false;
        string[] possibleNames = { "MusicVol", "MusicVolume", "musicVol", "musicVolume", "Music" };

        foreach (string paramName in possibleNames)
        {
            if (audioMixer.SetFloat(paramName, dB))
            {
                Debug.Log($"✅ Музыка установлена через параметр: {paramName}");
                success = true;
                break;
            }
        }

        if (!success)
        {
            Debug.LogError("❌ Не удалось найти параметр для музыки! Проверьте Audio Mixer.");
        }

        PlayerPrefs.SetFloat(PREF_MUSIC, value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        if (audioMixer == null) return;

        float dB = value > 0.001f ? Mathf.Log10(value) * 20f : -80f;

        // Пробуем разные варианты названий
        bool success = false;
        string[] possibleNames = { "SFXVol", "SFXVolume", "sfxVol", "sfxVolume", "SoundsVol", "SoundsVolume", "SFX" };

        foreach (string paramName in possibleNames)
        {
            if (audioMixer.SetFloat(paramName, dB))
            {
                Debug.Log($"✅ Звуки установлены через параметр: {paramName}");
                success = true;
                break;
            }
        }

        if (!success)
        {
            Debug.LogError("❌ Не удалось найти параметр для звуков! Проверьте Audio Mixer.");
        }

        PlayerPrefs.SetFloat(PREF_SFX, value);
        PlayerPrefs.Save();
    }

    public void SetBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            float exposure = Mathf.Lerp(-2f, 2f, value);
            colorAdjustments.postExposure.value = exposure;
            Debug.Log($"✅ Яркость: {value * 100:F0}% (exposure: {exposure:F2})");
        }
        else
        {
            Debug.LogWarning("⚠️ Post-Processing не настроен!");
        }

        PlayerPrefs.SetFloat(PREF_BRIGHTNESS, value);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        float savedMusic = PlayerPrefs.GetFloat(PREF_MUSIC, 1f);
        float savedSFX = PlayerPrefs.GetFloat(PREF_SFX, 1f);
        float savedBrightness = PlayerPrefs.GetFloat(PREF_BRIGHTNESS, 0.5f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;
        brightnessSlider.value = savedBrightness;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
        SetBrightness(savedBrightness);
    }
}