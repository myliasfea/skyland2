using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueZone : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textComponent;

    [Header("Dialogue Lines")]
    public string[] messages;

    [Header("Settings")]
    public float typingSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        textComponent.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void BeginDialogue()
    {
        gameObject.SetActive(true);
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        isTyping = true;
        textComponent.text = "";

        foreach (char c in messages[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame && !isTyping)
        {
            NextDialogue();
        }
    }

    void NextDialogue()
    {
        if (index < messages.Length - 1)
        {
            index++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}