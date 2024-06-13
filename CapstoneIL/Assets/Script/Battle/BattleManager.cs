using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [SerializeField] private GameObject endBattleCanvas; // Canvas untuk menampilkan setelah pertempuran selesai

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
            // Semua musuh telah terbunuh, tampilkan canvas endBattleCanvas
            endBattleCanvas.GetComponent<EndBattleCanvas>().ShowEndBattleCanvas();
        }
    }
}
