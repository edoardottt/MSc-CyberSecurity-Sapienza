import sqlite3

connection = sqlite3.connect("database.db")


with open("schema.sql") as f:
    connection.executescript(f.read())

cur = connection.cursor()

cur.execute(
    "INSERT INTO posts (title, content) VALUES (?, ?)",
    ("Hey! First post!", "just setting up my fsbc"),
)

cur.execute(
    "INSERT INTO posts (title, content) VALUES (?, ?)",
    ("Second Post", "Content for the second post in fsbc"),
)

connection.commit()
connection.close()
