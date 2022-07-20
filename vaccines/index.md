---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        %{ assign url =  page.permalink | append: item.id %}
        <li>
        <a href="{{ url | relative_url }}">{{item.name}}</a>
        <a href="{{ url | append: '/antigens'  | relative_url }}">(Antigens)</a>
        {% assign exp = 'path contains ' | append: url | append: '/conflicts' }
        {% assign file = site.static_files | find_exp: "path", frag %}
        {% if file %}        
        <a href="{{ url | append: '/conflicts'  | relative_url }}">(Conflicts)</a>
        {% endif %}
        </li>
    {% endfor %}
</ul>
