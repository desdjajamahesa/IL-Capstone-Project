using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBattleCanvas : MonoBehaviour
{
    public Text dialogText; // Komponen Text untuk menampilkan dialog
    public Button nextSceneButton; // Tombol untuk pindah ke scene berikutnya
    public Button mainMenuButton; // Tombol untuk kembali ke main menu

    public void ShowEndBattleCanvas()
    {
        gameObject.SetActive(true); // Aktifkan canvas

        // Tampilkan dialog atau pesan sesuai kebutuhan
        dialogText.text = "Congratulations! You have defeated all enemies.";

        // Aktifkan tombol-tombol
        nextSceneButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void GoToNextScene()
    {
        // Pindah ke scene berikutnya
        SceneManager.LoadScene("Intro");
    }

    public void GoToMainMenu()
    {
        // Kembali ke main menu
        SceneManager.LoadScene("StartMenu");
    }
}
