using Inventory.Model;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Deklarasikan data inventaris di sini
    private InventorySO inventoryData;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Objek ini tidak akan dihancurkan saat berpindah scene
            inventoryData = GetComponent<InventorySO>(); // Sesuaikan dengan metode inisialisasi data inventaris Anda
        }
        else
        {
            Destroy(gameObject); // Hancurkan objek jika instance lain sudah ada
        }
    }

    // Tambahkan metode untuk mengakses dan memperbarui inventaris
    public InventorySO GetInventoryData()
    {
        return inventoryData;
    }

    // Tambahkan metode lain sesuai kebutuhan
}
