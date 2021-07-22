import sqlite3

connection = sqlite3.connect("access.db")


with open("access.sql") as f:
    connection.executescript(f.read())

cur = connection.cursor()

cur.execute("INSERT INTO users (username, password) VALUES (?, ?)", ("user1yqtycvytyqwjhhefifb", "e3b0c44298fc1c149afbf4c8276fb92427ae41e4649b934ed205991b7852b855"))

cur.execute("INSERT INTO users (username, password) VALUES (?, ?)", ("user2yqtycvytyqwjhhefifb", "4bec9612cf41b3bfca2861aaea23a9e1eebfbe144f8e2cdaa5c1f1fe73de713f"))

cur.execute("INSERT INTO users (username, password) VALUES (?, ?)", ("user3yqtycvytyqwjhhefifb", "445c787614623dddde1cda0dd4f44bd2c72cd87738b9470b9959a10384bfc1c8"))

cur.execute("INSERT INTO users (username, password) VALUES (?, ?)", ("user4yqtycvytyqwjhhefifb", "60b3ed1102b750d064f75321f87945581f6c41ad611e8849849109e2065d9674"))

connection.commit()
connection.close()
