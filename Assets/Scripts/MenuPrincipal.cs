using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcoes;

    [SerializeField] private string nomeCenaJogo = "Jogo";

    private void Start()
    {
        Time.timeScale = 1f;
        MostrarMenu();
    }

    public void Jogar()
    {
        SceneManager.LoadScene(nomeCenaJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void Voltar()
    {
        MostrarMenu();
    }

    public void Sair()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void MostrarMenu()
    {
        painelOpcoes.SetActive(false);
        painelMenu.SetActive(true);
    }
}