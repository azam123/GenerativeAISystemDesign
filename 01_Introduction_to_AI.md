# 🌱 Introduction to Artificial Intelligence

🌱 Introduction to Artificial Intelligence
🧠 What is AI?

Artificial Intelligence (AI) is the science of creating systems that can perform tasks which normally require human intelligence — such as learning, decision-making, perception, or understanding language.

⚙️ Simple Analogy

When you use Google Maps to find the fastest route, AI is predicting the best path.
When Netflix recommends what to watch, AI is learning your taste.

Key Components of AI
| Component  | Description                             | Example                  |
|------------|-----------------------------------------|--------------------------|
| Learning   | Acquiring information and rules for using it. | Machine learning models |
| Reasoning  | Drawing conclusions based on data.       | Expert systems           |
| Perception | Understanding environment through inputs. | Image recognition       |
| Action     | Taking intelligent actions.              | Robotics, automation     |


🧮 Types of AI
| Type       | Description                          | Example          |
|------------|--------------------------------------|-----------------|
| Narrow AI  | AI designed for one specific task.    | Siri, Alexa     |
| General AI | AI with human-like cognitive abilities. | Not yet achieved |
| Super AI   | Beyond human intelligence.            | Theoretical stage |


💻 Simple AI Example (Python)
```python
    from sklearn.tree import DecisionTreeClassifier
    
    # Example: AI deciding if someone will buy a product
    X = [[25, 1], [30, 0], [45, 1], [35, 0]]  # age, interest flag
    y = ["Yes", "No", "Yes", "No"]
    
    model = DecisionTreeClassifier()
    model.fit(X, y)
    
    print(model.predict([[40, 1]]))

💻 Simple AI Example (.NET C#)

```csharp
using Microsoft.ML;
using Microsoft.ML.Data;
using System;

public class CustomerData
{
    [LoadColumn(0)] public float Age;
    [LoadColumn(1)] public float Interested;
    [LoadColumn(2)] public string Label;
}

class Program
{
    static void Main()
    {
        var mlContext = new MLContext();
        var data = mlContext.Data.LoadFromEnumerable(new[]
        {
            new CustomerData(){Age=25, Interested=1, Label="Yes"},
            new CustomerData(){Age=30, Interested=0, Label="No"}
        });

        var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
            .Append(mlContext.Transforms.Concatenate("Features", new[] {"Age","Interested"}))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

        var model = pipeline.Fit(data);
        Console.WriteLine("AI model trained successfully!");
    }
}


Next → [Generative AI Basics](https://github.com/azam123/GenerativeAISystemDesign/blob/main/02_Generative_AI_Basics.md)
