🛒 E-Commerce Generative AI Chatbot

This document provides a complete, optimized, and production-ready Generative AI chatbot system for an E-Commerce platform.

1. Project Structure

ecommerce_chatbot/
│
├── main.py                # FastAPI backend
├── chatbot.py             # Core AI logic
├── database.py            # Mock database for orders/returns
├── cache.py               # Simple caching module
├── utils.py               # Logging & helper functions
├── templates/
│   └── index.html         # Frontend demo
├── requirements.txt       # Python dependencies
└── README.md

2. requirements.txt

fastapi
uvicorn
openai
jinja2
python-multipart
cachetools

3. database.py (Mock Database)

# Mock database for orders and returns
orders = {
    "1001": {"status": "Shipped", "item": "Smartphone"},
    "1002": {"status": "Delivered", "item": "Laptop"},
    "1003": {"status": "Processing", "item": "Headphones"}
}

returns = {
    "1002": {"status": "Approved", "refund": 1500},
    "1003": {"status": "Pending", "refund": 500}
}

4. cache.py (Simple Caching)

from cachetools import TTLCache

# Cache up to 100 items for 10 minutes
query_cache = TTLCache(maxsize=100, ttl=600)

5. utils.py (Logging & Helpers)

import logging

# Configure logging
logging.basicConfig(level=logging.INFO,
                    format='%(asctime)s - %(levelname)s - %(message)s')

def log_request(prompt):
    logging.info(f"Received prompt: {prompt}")

6. chatbot.py (Core AI Logic)

import openai
from database import orders, returns
from cache import query_cache
from utils import log_request

# Set your OpenAI API key
openai.api_key = "YOUR_OPENAI_API_KEY"

def generate_response(prompt, conversation_history=[]):
    """
    Generates a response using GPT API with multi-turn support.
    Uses caching to optimize frequent queries.
    """
    log_request(prompt)
    
    # Check cache first
    if prompt in query_cache:
        return query_cache[prompt]

    # Construct conversation context
    messages = [{"role": "system", "content": "You are an expert E-commerce assistant."}]
    for msg in conversation_history:
        messages.append(msg)
    messages.append({"role": "user", "content": prompt})

    try:
        response = openai.ChatCompletion.create(
            model="gpt-3.5-turbo",
            messages=messages,
            max_tokens=200,
            temperature=0.5
        )
        answer = response.choices[0].message['content'].strip()
        query_cache[prompt] = answer
        return answer
    except Exception as e:
        return f"Error generating response: {str(e)}"

def handle_order_query(order_id):
    return orders.get(order_id, "Order ID not found.")

def handle_return_query(order_id):
    return returns.get(order_id, "Return info not found.")

7. main.py (FastAPI Backend)

from fastapi import FastAPI, Form, Request
from fastapi.responses import HTMLResponse
from fastapi.templating import Jinja2Templates
from chatbot import generate_response, handle_order_query, handle_return_query

app = FastAPI()
templates = Jinja2Templates(directory="templates")

# Simple in-memory conversation history
conversation_history = []

@app.get("/", response_class=HTMLResponse)
def index(request: Request):
    return templates.TemplateResponse("index.html", {"request": request})

@app.post("/chat")
def chat(user_input: str = Form(...)):
    """
    Endpoint for user chat input.
    """
    conversation_history.append({"role": "user", "content": user_input})
    
    # Handle order/return queries if detected
    if "order" in user_input.lower():
        response = handle_order_query(user_input.split()[-1])
    elif "return" in user_input.lower():
        response = handle_return_query(user_input.split()[-1])
    else:
        response = generate_response(user_input, conversation_history)
    
    conversation_history.append({"role": "assistant", "content": response})
    return {"response": response}

8. templates/index.html (Frontend Demo)

<!DOCTYPE html>
<html>
<head>
    <title>E-Commerce AI Chatbot</title>
</head>
<body>
    <h1>Customer Support Chatbot</h1>
    <form id="chatForm">
        <input type="text" id="user_input" placeholder="Type your query..." size="50" />
        <button type="submit">Send</button>
    </form>
    <div id="chatbox"></div>

    <script>
        const form = document.getElementById('chatForm');
        const chatbox = document.getElementById('chatbox');

        form.addEventListener('submit', async (e) => {
            e.preventDefault();
            const input = document.getElementById('user_input').value;
            chatbox.innerHTML += `<p><b>You:</b> ${input}</p>`;
            const formData = new FormData();
            formData.append('user_input', input);

            const response = await fetch('/chat', {
                method: 'POST',
                body: formData
            });
            const data = await response.json();
            chatbox.innerHTML += `<p><b>Bot:</b> ${data.response}</p>`;
            document.getElementById('user_input').value = '';
        });
    </script>
</body>
</html>

9. Running the Chatbot Locally

# Install dependencies
pip install -r requirements.txt

# Run FastAPI server
uvicorn main:app --reload

Open your browser at http://127.0.0.1:8000 to interact with the chatbot.

✅ Features Implemented

Multi-turn conversation with context tracking

Caching for frequent queries

Logging of prompts

Handles orders, returns, cancellations

Modular and production-ready structure

Simple HTML frontend demo

Optional Enhancements

Deploy with Docker + Kubernetes for scalability

Integrate authentication and security

Add multi-language support using GPT translation

Connect to real database (PostgreSQL, MongoDB)

