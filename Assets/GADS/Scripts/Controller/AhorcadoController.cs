using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AhorcadoController : BaseController
{
    [SerializeField] public string[] wordList;  // Lista de frases a adivinar
    [SerializeField] private string selectedWord;  // Palabra o frase seleccionada
    [SerializeField] private char[] guessedWord;  // Palabra o frase adivinada por el jugador
    [SerializeField] private int wrongGuesses;    // Número de intentos fallidos
    [SerializeField] private const int maxWrongGuesses = 6;  // Número máximo de intentos fallidos
    public TextMeshProUGUI wordDisplay;  // Mostrar palabra en la UI
    public TextMeshProUGUI wrongGuessesText;  // Mostrar número de intentos fallidos
    public Image hangmanImage;  // Imagen del ahorcado

    public override void OnSetView()
    {
        base.OnSetView();
        StartNewGame();
    }

    // Iniciar un nuevo juego
    void StartNewGame()
    {
        wrongGuesses = 0;
        selectedWord = wordList[Random.Range(0, wordList.Length)].ToUpper();  // Convertir la palabra seleccionada a mayúsculas
        guessedWord = CreateGuessedWord(selectedWord);
        wordDisplay.text = new string(guessedWord);
        wrongGuessesText.text = "Wrong Guesses: " + wrongGuesses;
        hangmanImage.sprite = null;  // Resetear imagen del ahorcado
    }

    // Método para crear el array de letras adivinadas, manteniendo los espacios
    char[] CreateGuessedWord(string word)
    {
        char[] guessed = new char[word.Length];

        // Iterar a través de la palabra, si es un espacio, asignar un espacio en guessedWord, si no, poner un '_'
        for (int i = 0; i < word.Length; i++)
        {
            guessed[i] = word[i] == ' ' ? ' ' : '_';
        }

        return guessed;
    }

    // Método para adivinar una letra
    public void GuessLetter(char letter)
    {
        bool found = false;

        // Buscar la letra en la palabra
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == letter)
            {
                guessedWord[i] = letter;
                found = true;
            }
        }

        if (!found)
        {
            wrongGuesses++;
            hangmanImage.sprite = Resources.Load<Sprite>("hangman" + wrongGuesses);  // Mostrar parte del ahorcado
        }

        wordDisplay.text = new string(guessedWord);
        wrongGuessesText.text = "Wrong Guesses: " + wrongGuesses;

        if (wrongGuesses >= maxWrongGuesses)
        {
            // Mostrar mensaje de "Game Over"
            Debug.Log("Game Over!");
        }
        else if (new string(guessedWord) == selectedWord)
        {
            // Mostrar mensaje de "Ganaste"
            Debug.Log("You Win!");
        }
    }
}
