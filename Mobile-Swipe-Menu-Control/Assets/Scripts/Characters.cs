using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public GameObject[] characters;
    public Material[] character_Materials;
    
    private int current_Character_Index = 0;

    public void ChangeCharacter(int index)
    {
        current_Character_Index += index; // Add to index

        // If we are out of bounds (0, characters.Lenght), 
        if (current_Character_Index < 0)
        {
            current_Character_Index = characters.Length - 1;
        }
        
        else if (current_Character_Index > characters.Length - 1)
        {
            current_Character_Index = 0;
        }

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false); // Close all other characters
        }
        
        // Activate chosen object
        characters[current_Character_Index].SetActive(true);
    }

    // Color hex codes, we will change material colors with hex codes
    // You can also check my Gist about changing of material color: gist.github.com/ouzdmrkl/3c2a620b8d54632d8443a381d9bbd7c2
    private string[] color_Hex = {"#FF0000", "#FFEC00", "#3EFF00", "#002EFF", "#AA00FF", "#FF00AA", "#FF7C00"};
    private Color color;
    private int current_Color_Index = 0;
    
    // Same logic like character select
    public void ColorCharacter(int index)
    {
        current_Color_Index += index; 
        
        if (current_Color_Index < 0)
        {
            current_Color_Index = color_Hex.Length - 1;
        }
        
        else if (current_Color_Index > color_Hex.Length - 1)
        {
            current_Color_Index = 0;
        }
        
        ColorUtility.TryParseHtmlString(color_Hex[current_Color_Index], out color);
        
        character_Materials[current_Character_Index].color = color;
    }
}
