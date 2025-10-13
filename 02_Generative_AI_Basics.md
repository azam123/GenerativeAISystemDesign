# 🎨 Understanding Generative AI

🎨 Understanding Generative AI
🌍 What is Generative AI?

Generative AI is a branch of Artificial Intelligence that focuses on creating new data — text, images, videos, or music — similar to what humans can produce.

It learns patterns from existing data and then generates new, similar content.

🧠 Examples of Generative AI in Action
Tool	Output	Description
ChatGPT	Text	Writes stories, code, or answers
DALL·E	Images	Generates images from text
Jukebox	Music	Composes music based on prompts
🧩 Simple Example (Python)
```python
from transformers import pipeline

generator = pipeline("text-generation", model="gpt2")
result = generator("Once upon a time in Mumbai,", max_length=40)
print(result[0]['generated_text'])

💻 Simple Example (.NET C#)
```csharp
using OpenAI_API;

var api = new OpenAIAPI("YOUR_API_KEY");
var result = await api.Completions.CreateCompletionAsync("Once upon a time in Mumbai,", max_tokens: 40);
Console.WriteLine(result);
```

**⚙️ How Generative AI Works**


<img width="572" height="390" alt="image" src="https://github.com/user-attachments/assets/8b3aad71-47cd-4e22-8556-a4d3c3322307" />

🔍 Core Concepts
Concept	Description	Example
Prompt	The instruction or input text.	"Write a poem on Diwali"
Tokenization	Converting text to numeric format.	NLP preprocessing
Transformer	Neural network model for understanding text context.	GPT, BERT
Training	Learning patterns from large datasets.	Model fine-tuning

