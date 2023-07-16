using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUiChat : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_InputField _inputFieldApiKey;
    [SerializeField] private Button _sendButton;
    [SerializeField] private Button _sendApiKeyButton;
    [SerializeField] private TextMeshProUGUI _textResult;

    private void Start()
    {
        _sendButton.onClick.AddListener(SendMessage);
        _sendApiKeyButton.onClick.AddListener(SetApiKey);
    }

    private void SetApiKey() => PythonScriptRunner.ApiKey = _inputFieldApiKey.text;

    private void OnEnable() => Application.logMessageReceived += HandleLogMessage;

    private void OnDisable() => Application.logMessageReceived -= HandleLogMessage;

    private void SendMessage()
    {
        _textResult.text = "Wait please...";
        _sendButton.interactable = false;
        var textRequest = _inputField.text;       
        _inputField.text = "";
        
        PythonScriptRunner.SendMessageChatGPT(textRequest);
    }

    private void HandlerResultChatGPT(string logString)
    {
        _textResult.text = logString;
        _sendButton.interactable = true; 
    }

    private void HandleLogMessage(string logString, string stackTrace, LogType type)
    {
        if (logString.StartsWith("ChatGPT: "))
        {
            HandlerResultChatGPT(logString);
        } 
    }
}