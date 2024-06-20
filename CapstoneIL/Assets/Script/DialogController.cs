using System.Collections;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel; // Reference to the dialog panel
    public TextMeshProUGUI dialogText; // Reference to the TextMeshProUGUI component
    public float displayDuration = 5f; // Duration for which the dialog is displayed
    public float wordSpeed = 0.05f; // Speed at which words appear

    private float timer;
    private bool isDialogActive;
    private Coroutine displayCoroutine;

    void Start()
    {
        // Set the initial dialog text and make sure the panel is visible
        ShowDialog("Tutorial", displayDuration);
    }

    void Update()
    {
        if (isDialogActive)
        {
            // Countdown timer
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    // Hide the dialog panel after the timer expires
                    dialogPanel.SetActive(false);
                    isDialogActive = false;
                }
            }
        }
    }

    // This method can be called to display a new dialog
    public void ShowDialog(string newDialog, float duration)
    {
        // Stop any ongoing text display coroutine
        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        displayDuration = duration;
        timer = duration;
        dialogPanel.SetActive(true);
        isDialogActive = true;

        // Start the coroutine to display text with word speed
        displayCoroutine = StartCoroutine(DisplayText(newDialog));
    }

    private IEnumerator DisplayText(string dialog)
    {
        dialogText.text = "";
        foreach (char letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
