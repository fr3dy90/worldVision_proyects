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
        Reflexion,
        //////////////// OVA 2 //////////////////
        Momento_1,
        Momento_2,
        Momento_3,
        TomaDecisiones,
        HerramientaEstrategias,
        EnContextoI,
        EnContextoII,
        Revisemos
        //////////////// OVA 2 //////////////////
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
    public struct BasicDataStruct
    {
        [TextArea(3,3)] public string MainQuest;
        [TextArea(3,3)] public string OptionI;
        [TextArea(3,3)] public string OptionII;
    }
    
    [System.Serializable]
    public struct SimpleDataStruct
    {
        [TextArea(3,3)] public string Title;
        [TextArea(3,3)]public string Paragraph;
    }
    
}
