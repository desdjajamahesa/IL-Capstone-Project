using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Tambahkan ini untuk mengakses komponen UI
using UnityEngine.SceneManagement; // Tambahkan ini untuk manajemen scene

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private Slider healthBar; // Tambahkan ini untuk referensi ke UI Slider
    [SerializeField] private GameObject deathDialogPanel; // Tambahkan ini untuk referensi ke Panel Dialog Kematian
    [SerializeField] private string mainMenuSceneName = "MainMenuScene"; // Nama scene untuk main menu

    private int currentHealth;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth; // Atur nilai maksimum health bar
        UpdateHealthBar(); // Perbarui health bar saat mulai
        deathDialogPanel.SetActive(false); // Pastikan Panel Dialog Kematian dimatikan di awal
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy && canTakeDamage)
        {
            TakeDamage(1);
            knockback.GetKnockedBack(other.gameObject.transform, knockBackThrustAmount);
            knockback.GetKnockedBack(PlayerControllerr.Instance.transform, 15f);
            StartCoroutine(flash.FlashRoutine());
        }
    }

    private void TakeDamage(int damageAmount)
    {
        
        

        canTakeDamage = false;
        currentHealth -= damageAmount;
        UpdateHealthBar(); // Perbarui health bar setelah menerima kerusakan

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(DamageRecoveryRoutine());
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth; // Perbarui nilai health bar
    }

    private void Die()
    {
        // Logika kematian pemain
        Debug.Log("Pemain mati!");
        Instantiate(deathVFXPrefab, transform.position, Quaternion.identity); // Tampilkan efek kematian
        ShowDeathDialog(); // Tampilkan dialog kematian
    }

    private void ShowDeathDialog()
    {
        deathDialogPanel.SetActive(true); // Aktifkan Panel Dialog Kematian
        Time.timeScale = 0; // Hentikan waktu permainan
    }

    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1; // Kembalikan waktu permainan
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Muat ulang scene saat ini
    }

    public void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1; // Kembalikan waktu permainan
        SceneManager.LoadScene(mainMenuSceneName); // Pindah ke scene main menu
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
