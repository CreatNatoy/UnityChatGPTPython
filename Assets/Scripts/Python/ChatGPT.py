import UnityEngine
import openai
import json

def process_json(json_data):
    data = json.loads(json_data)
    
    api_key = data["ApiKey"]
    massage = data["Massage"]
    
    openai.api_key = api_key

    def chat_with_chatgpt(prompt, model="gpt-3.5-turbo"):
        response = openai.ChatCompletion.create(
            model=model,
            messages=[
                {"role": "system", "content": "You are a helpful assistant."},
                {"role": "user", "content": prompt}
            ]
        )

        message = response.choices[0].message.content
        return message

    response = chat_with_chatgpt(massage)
    response = "ChatGPT: " + response 
    print("Ответ:", response)
    UnityEngine.Debug.Log(response)

process_json(__name__)
