---
title: Data View
layout: default
---


<h2 class="w3-container w3-left-align w3-theme w3-round">{{ page.title }}</h2>

<div class="w3-card">
<header class="w3-container w3-theme-l2">
<h3 id="data-view-header"></h3>
</header>
<pre id="data-view" class="w3-container" style="white-space: pre-wrap;">
</pre>
</div>

<script>
var urlSearchParams = new URLSearchParams(window.location.search);
var params = Object.fromEntries(urlSearchParams.entries());

fetch(params.url).then(r=>{
    if (!r.ok) {
      throw new Error(`HTTP error: ${r.status}`);
    }
    return r.json();
    })
    .then(display)
    .then(()=>card(params.url))
    .catch(display);

function card(url){
  var components = url.split('/');
  var txt = `${titlecase(components[1])} ${components[2]}`;
  var el = document.getElementById('data-view-header');
  el.innerText=txt;
}

function display(obj){
    var txt =document.createTextNode( JSON.stringify(obj, null, 2));
    var div = document.getElementById("data-view");
    div.appendChild(txt); 
}

function titlecase(str){
  return str.toLowerCase()
            .split(' ')
            .map(w => w[0].toUpperCase() + w.slice(1,-1))
            .join(' ');
}
</script>