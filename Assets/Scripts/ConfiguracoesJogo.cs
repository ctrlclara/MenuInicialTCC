using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ConfiguracoesJogo : MonoBehaviour
{
    [SerializeField] private AudioMixer mixerPrincipal;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Toggle toggleTelaCheia;

    private const string ParametroVolume = "VolumeMaster";

    private const string ChaveVolume = "config_volume";
    private const string ChaveTelaCheia = "config_tela_cheia";

    private const float VolumePadrao = 0.75f;
    private const float VolumeMinimo = 0.0001f;

    private void Start()
    {
        float volumeSalvo = PlayerPrefs.GetFloat(ChaveVolume, VolumePadrao);
        sliderVolume.SetValueWithoutNotify(volumeSalvo);
        AplicarVolume(volumeSalvo);

        int padraoTelaCheia = Screen.fullScreen ? 1 : 0;
        bool telaCheiaSalva = PlayerPrefs.GetInt(ChaveTelaCheia, padraoTelaCheia) == 1;
        toggleTelaCheia.SetIsOnWithoutNotify(telaCheiaSalva);
        AplicarTelaCheia(telaCheiaSalva);
    }

    public void DefinirVolume(float valor)
    {
        AplicarVolume(valor);
        PlayerPrefs.SetFloat(ChaveVolume, valor);
    }

    public void DefinirTelaCheia(bool ativa)
    {
        AplicarTelaCheia(ativa);
        PlayerPrefs.SetInt(ChaveTelaCheia, ativa ? 1 : 0);
    }

    private void AplicarVolume(float valorLinear)
    {
        float valorSeguro = Mathf.Max(valorLinear, VolumeMinimo);
        float decibeis = Mathf.Log10(valorSeguro) * 20f;
        mixerPrincipal.SetFloat(ParametroVolume, decibeis);
    }

    private void AplicarTelaCheia(bool ativa)
    {
        Screen.fullScreenMode = ativa ? FullScreenMode.FullScreenWindow
                                      : FullScreenMode.Windowed;
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
}