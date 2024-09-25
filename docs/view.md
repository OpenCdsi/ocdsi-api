---
title: Data View
layout: default
---

<div class="w3-card">
    <h2  class="w3-container w3-left-align w3-theme w3-text-white" id="data-view-header"></h2>
 
    <pre class="w3-border-0 w3-white w3-container" id="data-view" style="white-space: pre-wrap;"></pre>
      
    <footer class="w3-container">
      <a href="#" onclick="history.back()">Back</a>
    </footer>
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
  var txt = `${titlecase(components[2])}: ${components[3]}`;
  var el = document.getElementById('data-view-header');
  el.innerText=txt;
}

function display(obj){
    var txt =document.createTextNode( JSON.stringify(obj, null, 2));
    var el = document.getElementById("data-view");
    el.appendChild(txt); 
}

function titlecase(str){
  return str.toLowerCase()
            .split(' ')
            .map(w => w[0].toUpperCase() + w.slice(1,-1))
            .join(' ');
}
</script>
