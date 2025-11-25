from flask import Flask
import requests

app = Flask(__name__)

@app.get("/")
def root():
    resp = requests.get("https://httpbin.org/get", timeout=5)
    return {"status_code": resp.status_code}

if __name__ == "__main__":
    app.run(debug=True)
