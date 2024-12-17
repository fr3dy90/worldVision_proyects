using UnityEngine;

[CreateAssetMenu(fileName = "ColorModel", menuName = "GADS/ColorModel")]
public class ColorModel : ScriptableObject
{
   public Sprite[] titleContent;
   public Color[] _colorBackground;
   public Color[] _colorTextContent;
   public Color[] _colorTitle;
}
