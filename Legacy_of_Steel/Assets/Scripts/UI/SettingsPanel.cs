using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Панель настроек. Вешай на объект SettingsPanel.
/// </summary>
public class SettingsPanel : MonoBehaviour
{
    [Header("Слайдеры")]
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider masterSlider;

    [Header("Текстовые подписи значений")]
    public TextMeshProUGUI musicValueText;
    public TextMeshProUGUI sfxValueText;
    public TextMeshProUGUI masterValueText;

    [Header("Кнопка закрыть")]
    public Button closeButton;

    private void Start()
    {
        // Загружаем сохранённые настройки (или дефолт 80%)
        if (musicSlider  != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
            musicSlider.onValueChanged.AddListener(OnMusicChanged);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
            sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        }

        if (masterSlider != null)
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
            masterSlider.onValueChanged.AddListener(OnMasterChanged);
        }

        if (closeButton != null)
            closeButton.onClick.AddListener(Close);

        UpdateAllTexts();
        gameObject.SetActive(false); // по умолчанию скрыта
    }

    // ─── Обработчики ──────────────────────────────────────────────────────────

    private void OnMusicChanged(float val)
    {
        PlayerPrefs.SetFloat("MusicVolume", val);
        if (musicValueText != null) musicValueText.text = Mathf.RoundToInt(val * 100) + "%";
        // Если есть AudioMixer: musicMixer.SetFloat("MusicVol", Mathf.Log10(val) * 20);
    }

    private void OnSFXChanged(float val)
    {
        PlayerPrefs.SetFloat("SFXVolume", val);
        if (sfxValueText != null) sfxValueText.text = Mathf.RoundToInt(val * 100) + "%";
    }

    private void OnMasterChanged(float val)
    {
        PlayerPrefs.SetFloat("MasterVolume", val);
        AudioListener.volume = val;
        if (masterValueText != null) masterValueText.text = Mathf.RoundToInt(val * 100) + "%";
    }

    // ─── Публичные методы ─────────────────────────────────────────────────────

    public void Open()  => gameObject.SetActive(true);
    public void Close() => gameObject.SetActive(false);

    // ─── Хелпер ───────────────────────────────────────────────────────────────

    private void UpdateAllTexts()
    {
        if (musicValueText  != null && musicSlider  != null)
            musicValueText.text  = Mathf.RoundToInt(musicSlider.value  * 100) + "%";
        if (sfxValueText    != null && sfxSlider    != null)
            sfxValueText.text    = Mathf.RoundToInt(sfxSlider.value    * 100) + "%";
        if (masterValueText != null && masterSlider != null)
            masterValueText.text = Mathf.RoundToInt(masterSlider.value * 100) + "%";
    }
}
