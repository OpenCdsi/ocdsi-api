---
title: Data View
layout: default
---


<h2 class="w3-container w3-left-align w3-theme w3-round">{{ page.title }}</h2>

<div id="data-view"></div>

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
    .catch(display);


function display(obj){
    var txt = JSON.stringify(obj, null, 4);
    var el = document.createElement("pre");
    el.style.cssText+="white-space: pre-wrap";
    el.classList +=  "w3-container";
    el.classList += "w3-round";
    el.append(txt);
    var div = document.getElementById("data-view");
    div.append(el);
}
</script>