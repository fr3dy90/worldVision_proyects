using UnityEngine;


[CreateAssetMenu(fileName = "New Dialog", menuName = "GADS/Dialog", order = 1)]

public class DialogModel : ScriptableObject
{
    public Dialog[] Dialogs;
}

[System.Serializable]
public class Dialog
{
    public string characterName;
    public Sprite characterImage;  // Imagen del personaje
    [TextArea(3,3)]public string[] dialogLines;   // Líneas de diálogo
    public float timeToDisplay = 2f; // Tiempo para mostrar cada línea de texto
    public bool typewriterEffect = true; // ¿Usar efecto tipo máquina de escribir?

    // Opciones de avance (por tiempo o por botón)
    public bool advanceAutomatically = false;
    public bool autoAdvanceWithTime = true;  // Avance con tiempo
}
