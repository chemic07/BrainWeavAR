using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenAI;
using OpenAI.Models;
using TMPro;

public class ChatGPT : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text displayText;
    private string userInput;
    private string chatHistory;
    private string aiIdentity = "Act as a teacher who is cool"; 
    private OpenAIClient api;

    private void Start()
    {
        chatHistory += aiIdentity + "\n";
        api = new OpenAIClient(new OpenAIAuthentication("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")); 
    }

    private async void AskAI()
    {
        button.enabled = false;
        inputField.enabled = false;
        userInput = inputField.text;
        chatHistory += $"{userInput}.\n";
        displayText.text = ".....";
        inputField.text = "....";

        var result = await api.CompletionsEndpoint.CreateCompletionAsync(chatHistory, maxTokens: 200, model: Model.Davinci); 

        displayText.text = result.ToString();
        chatHistory += $" {result.ToString()}\n";

        button.enabled = true;
        inputField.enabled = true;
    }
}

