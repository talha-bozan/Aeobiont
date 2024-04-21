using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpriteColorManager : MonoBehaviour
{
    public Sprite[] spriteSheet; // Array of sprites forming the sprite sheet
    public GameObject colorPrefab; // Prefab for displaying a unique color
    public Transform parentTransform; // Parent for color display UI
    public Image targetSpriteRenderer; // Sprite renderer to update colors

    private List<Color> uniqueColors = new List<Color>();
    private Dictionary<Color, GameObject> colorObjects = new Dictionary<Color, GameObject>();

    void Start()
    {
        GetUniqueColorsFromSprites(spriteSheet);
    }
    // Function to extract unique colors from a sprite sheet
    private List<Color> GetUniqueColorsFromSprites(Sprite[] sprites)
    {
        HashSet<Color> uniqueColorsSet = new HashSet<Color>();

        foreach (Sprite sprite in sprites)
        {
            Texture2D texture = sprite.texture;
            Color[] allColors = texture.GetPixels();

            foreach (Color color in allColors)
            {
                uniqueColorsSet.Add(color);
            }
        }

        return uniqueColorsSet.ToList();
    }

   
}
