import sqlite3
import re
from flask import (
    Flask,
    render_template,
    render_template_string,
    request,
    url_for,
    flash,
    redirect,
    escape,
)
from werkzeug.exceptions import abort


def get_db_connection():
    conn = sqlite3.connect("database.db")
    conn.row_factory = sqlite3.Row
    return conn


def get_post(post_id):
    if not isinstance(post_id, int):
        abort(404)
    conn = get_db_connection()
    post = conn.execute("SELECT * FROM posts WHERE id = ?", (post_id,)).fetchone()
    conn.close()
    if post is None:
        abort(404)
    return post


app = Flask(__name__)
with open("key.txt", "r+") as f:
    key = f.read()
app.config["SECRET_KEY"] = key


@app.route("/")
def index():
    conn = get_db_connection()
    posts = conn.execute("SELECT * FROM posts").fetchall()
    conn.close()
    return render_template("index.html", posts=posts)


@app.route("/<int:post_id>")
def post(post_id):
    post = get_post(post_id)
    return render_template("post.html", post=post)


@app.route("/user")
def user():
    return render_template("users.html")


@app.route("/user/<user>")
def profile_page(user):

    template = """
    <!doctype html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <title>{% block title %} {% endblock %}</title>
</head>

<body>
    <nav class="navbar navbar-dark bg-primary navbar-expand-md">
        <a class="navbar-brand" href="{{ url_for('index')}}">FeisBuc</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
            aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class=" collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item active">
                    <a class="nav-link" href="#">About</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="{{url_for('user')}}">Users</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="{{url_for('create')}}">New Post</a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="container">
    """
    template = template + f"Welcome to the {user}'s profile!"
    template += """
    </div>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
        crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
        integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
        crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
        integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
        crossorigin="anonymous"></script>
</body>

</html>
    """
    if(isUserOkay(user)):
        return render_template_string(template)
    else:
        abort(404)


@app.route("/create", methods=("GET", "POST"))
def create():
    if request.method == "POST":
        title = request.form["title"]
        content = request.form["content"]

        if not title:
            flash("Title is required!")
        if not re.match("^[A-Za-z0-9_-]*$", title):
            flash("Title can only contains letters and numbers!")
        if not re.match("^[A-Za-z0-9_-]*$", content):
            flash("Content can only contains letters and numbers!")

        else:
            title = escape(title)
            content = escape(content)
            conn = get_db_connection()
            conn.execute(
                "INSERT INTO posts (title, content) VALUES (?, ?)", (title, content)
            )
            conn.commit()
            conn.close()
            return redirect(url_for("index"))

    return render_template("create.html")


@app.route("/<int:id>/edit", methods=("GET", "POST"))
def edit(id):
    post = get_post(id)

    if not isinstance(id, int):
        abort(404)

    if request.method == "POST":
        title = request.form["title"].replace(" ", "")
        content = request.form["content"].replace(" ", "")

        if not title:
            flash("Title is required!")
        if not re.match("^[A-Za-z0-9_-]*$", title):
            flash("Title can only contains letters and numbers!")
        if not re.match("^[A-Za-z0-9_-]*$", content):
            flash("Content can only contains letters and numbers!")
        else:
            title = escape(title)
            content = escape(content)
            conn = get_db_connection()
            conn.execute(
                "UPDATE posts SET title = ?, content = ?" " WHERE id = ?",
                (title, content, id),
            )
            conn.commit()
            conn.close()
            return redirect(url_for("index"))

    return render_template("edit.html", post=post)


@app.route("/<int:id>/delete", methods=("POST",))
def delete(id):
    if not isinstance(id, int):
        abort(404)
    post = get_post(id)
    conn = get_db_connection()
    conn.execute("DELETE FROM posts WHERE id = ?", (id,))
    conn.commit()
    conn.close()
    flash('"{}" was successfully deleted!'.format(post["title"]))
    return redirect(url_for("index"))

def isUserOkay(user):
    user = user.lower()
    not_allowed = ["/","\\","<",">","script","img","error","php","localhost","127.0.0.1","alert"]
    for elem in not_allowed:
        if elem in user:
            return False
    return True