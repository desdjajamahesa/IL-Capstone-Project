using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource typingSource; // AudioSource untuk suara mengetik

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Agar AudioManager persisten di antara scene
    }

    // Fungsi untuk memainkan suara mengetik
    public void PlayTypingSound()
    {
        typingSource.Play();
    }
}
