---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li>
        [ {{item.name}} ]( {{ page.permalink | append: item.id  | relative_url }} )   
        </li>
    {% endfor %}
</ul>
