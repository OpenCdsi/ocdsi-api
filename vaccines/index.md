---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.vaccine %}
        {% assign url =  page.permalink | append: item.id %}
        <li>
        <a href="{{ url | relative_url }}">{{item.name}}</a>
        <a href="{{ url | append: '/antigens'  | relative_url }}">(Antigens)</a>
        {% if item.conflicts %}
        <a href="{{ url | append: '/conflicts'  | relative_url }}">(Conflicts)</a>
        {% endif %}
        </li>
    {% endfor %}
</ul>