using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SonsMenuPrincipal : MonoBehaviour
{
    [SerializeField] private AudioClip somClique;
    [SerializeField] private AudioMixerGroup saida;

    private static AudioSource fonte;

    private void Start()
    {
        Button[] botoes = GetComponentsInChildren<Button>(true);

        if (botoes.Length == 0)
            Debug.LogWarning("SonsMenuPrincipal: nenhum botão encontrado abaixo deste objeto. Coloque o script no Canvas do menu.");

        foreach (Button botao in botoes)
            botao.onClick.AddListener(TocarClique);
    }

    private void TocarClique()
    {
        if (somClique == null) return;
        ObterFonte().PlayOneShot(somClique);
    }

    private AudioSource ObterFonte()
    {
        if (fonte == null)
        {
            GameObject obj = new GameObject("SomMenuPrincipal");
            DontDestroyOnLoad(obj);
            fonte = obj.AddComponent<AudioSource>();
            fonte.playOnAwake = false;
            fonte.outputAudioMixerGroup = saida;
        }
        return fonte;
    }
}