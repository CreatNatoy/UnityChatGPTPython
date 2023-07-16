using UnityEditor.Scripting.Python;
using UnityEngine;

public partial class PythonScriptRunner : MonoBehaviour
{
    public static string ApiKey = ""; 
    
    public static void SendMessageChatGPT(string massage)
    {
        string scriptPath = Application.dataPath + "/Scripts/Python/ChatGPT.py";
        var massagePython = new MassagePython(ApiKey, massage);
        string data = JsonUtility.ToJson(massagePython); 

        // Запускаем питон-скрипт
        PythonRunner.RunFile(scriptPath, data);
    }
}