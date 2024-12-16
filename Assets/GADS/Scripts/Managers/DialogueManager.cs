using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Action OnComplete;
    
    public DialogModel test;
    public int index = 0;
    
    [Header("UI References")]
    public Image characterImage;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogText;
    public Button nextButton;
    public GameObject dialogPanel;

    [Header("Dialog Settings")]
    public Dialog currentDialog; // Modelo de datos con la información del diálogo
    private int currentLineIndex = 0; // Para llevar un control de la línea de diálogo

    private bool isTyping = false;

    void Start()
    {
         // Conectar el botón de avance
        // Iniciar el botón oculto si no se quiere avanzar con el botón
        
    }

    public void InitializeDialog(int _index)
    {
        index = _index;
        dialogPanel.SetActive(false);
        nextButton.onClick.AddListener(AdvanceDialog);
    }

    public void StartCurrentDialog(int index)
    {
        currentDialog = test.Dialogs[index];
        nextButton.gameObject.SetActive(false);
        StartDialog(currentDialog);

    }

    // Iniciar el diálogo
    public void StartDialog(Dialog dialog)
    {
        currentDialog = dialog;
        currentLineIndex = 0;

        // Mostrar la imagen y el nombre del personaje
        characterImage.sprite = dialog.characterImage;
        characterNameText.text = dialog.characterName;

        if (dialogPanel.activeSelf == false)
        {
            dialogPanel.SetActive(true);
        }

        ShowNextLine();
    }

    // Mostrar la siguiente línea de diálogo
    async void ShowNextLine()
    {
        if (currentLineIndex >= currentDialog.dialogLines.Length)
        {
            EndDialog();
            return;
        }

        // Mostrar la línea de texto
        string line = currentDialog.dialogLines[currentLineIndex];
        dialogText.text = "";
        await DisplayText(line);

        currentLineIndex++;
    } 

    // Mostrar el texto con el efecto de máquina de escribir
    async UniTask DisplayText(string line)
    {
        isTyping = true;
        nextButton.gameObject.SetActive(false); // Ocultar el botón mientras el texto se muestra

        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            if (currentDialog.autoAdvanceWithTime)
            {
                await UniTask.WaitForSeconds(currentDialog.timeToDisplay / line.Length); // Esperar un tiempo entre letras
            }
            else
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }

        isTyping = false;

        // Mostrar el botón si el texto se ha mostrado completamente
        if (!currentDialog.autoAdvanceWithTime)
        {
            nextButton.gameObject.SetActive(true);
        }
    }

    // Avanzar el diálogo (al pulsar el botón o si se ha completado el texto)
    public void AdvanceDialog()
    {
        if (isTyping)
        {
            // Si el texto está escribiéndose, detener el efecto y mostrarlo todo
            StopAllCoroutines();
            dialogText.text = currentDialog.dialogLines[currentLineIndex - 1];
        }
        else
        {
            // Avanzar al siguiente diálogo
            ShowNextLine();
        }
    }

    // Finalizar el diálogo
    void EndDialog()
    {
        dialogPanel.SetActive(false); // Desactivar el panel de diálogo
        
        Debug.Log("Diálogo finalizado.");

        index++;
        if (index < test.Dialogs.Length)
        {
            StartDialog(test.Dialogs[index]);
        }
        else
        {
            OnComplete?.Invoke();
        }
            
    }
}