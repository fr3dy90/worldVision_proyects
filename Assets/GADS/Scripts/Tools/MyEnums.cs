using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MyEnums : MonoBehaviour
{
    public enum GameState
    {
        None,
        Logos,
        Intro,
        Menu,
        Concentrese,
        QueSera,
        Palabrero,
        Palabrero_2,
        QueHarias,
        Ahorcado,
        Reflexion
    }

    public enum MainMenuStep
    {
        None,
        Concentrece,
        QueSera,
        Palabrero,
        Palabrero2,
        QueHarias,
        Ahorcado
    }
    
    public enum Emocion
    {
        None,
        Irritabilidad,
        Optimizmo,
        Curiosidad,
        Ansiedad,
        Entusiasmo,
        Confusion,
        Tranquilidad,
        Frustrasion,
        Incertidumbre,
        Indiferencia,
        Satisfaccon
    }
    
    [System.Serializable]
    public struct QueSeraStruct
    {
        [TextArea(3, 3)] public string definicion;
        public Emocion id;
    }
    
    [System.Serializable] 
    public struct PalabreroI
    {
        public TMP_InputField word;
        public TMP_InputField wordII;
    }
    
    [System.Serializable]
    public struct PalabreroII
    {
        public Button button;
        public Button buttonII;
        public bool isAnswered;
    }
    
    [System.Serializable]
    public struct QueHariasStruct
    {
        [TextArea(3,3)] public string Situacion;
        [TextArea(3,3)] public string optionI;
        [TextArea(3,3)] public string optionII;
    }
}
