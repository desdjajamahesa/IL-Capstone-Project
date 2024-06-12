using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [SerializeField] private string nextSceneName; // Nama scene berikutnya

    private int enemiesAlive = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy()
    {
        enemiesAlive++;
        Debug.Log("Enemy registered. Total enemies: " + enemiesAlive);
    }

    public void UnregisterEnemy()
    {
        enemiesAlive--;
        Debug.Log("Enemy unregistered. Total enemies: " + enemiesAlive);

        if (enemiesAlive <= 0)
        {
            // Semua musuh telah terbunuh, pindah ke scene berikutnya
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
