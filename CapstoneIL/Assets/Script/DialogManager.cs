using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText; // Referensi ke komponen Text di UI
    public GameObject dialogBox; // Panel UI untuk dialog
    private Queue<string> sentences; // Queue untuk menyimpan kalimat dialog

    void Start()
    {
        sentences = new Queue<string>();
        dialogBox.SetActive(false); // Sembunyikan dialog box pada awalnya
    }

    public void StartDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        dialogBox.SetActive(false);
    }
}
