using System.IO;
using UnityEditor;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    static string[] Contents = { "Audio", "Materials", "UI", "Sprites", "Textures", "Animation", "Model" };
    [MenuItem("Tools/Project/Create Folders &f")]
    private static void CreateFolders()
    {
        bool b = true;
        if (b == true)
        {
            foreach (var VARIABLE in Contents)
            {
                Directory.CreateDirectory("Assets/Contents/" + VARIABLE);
            }
            Directory.CreateDirectory("Assets/Externals");
            Directory.CreateDirectory("Assets/Scenes");
            Directory.CreateDirectory("Assets/Prefabs");
            Directory.CreateDirectory("Assets/Scripts");
            AssetDatabase.Refresh();
            b = false;
        }
    }
}