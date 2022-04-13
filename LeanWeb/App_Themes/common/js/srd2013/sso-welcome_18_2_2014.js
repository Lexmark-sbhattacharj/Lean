/* Injects welcome message into the SSO login page */
$(function () {
	$("#article").empty().append(
	'<h1>Welcome to Lexmark</h1>' +
	'<h2>HRLeave</h2>' +
	'<p>At Lexmark, our entire focus is on making your print experience better, smarter, and more efficient. Online, the best way to take advantage of this committment is to open a free account.</p>' +
	'<ul class="bulleted">' +
	'  <li>For further information, please contact:</li>' +
	'  <li>JOYCE YAO</li>' +
	'  <li>PH: +86 10 85190378</li>' +
	'  <li>Email: joyyao@lexmark.com</li>' +
	'</ul>');
});
