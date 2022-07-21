---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        {% assign url =  page.permalink | append: item.id %}
        <li>
        <a href="{{ url | relative_url }}">{{item.name}}</a>
        <a href="{{ url | append: '/antigens'  | relative_url }}">(Antigens)</a>
        {% capture exp %}
        {{ "path.includes('" | append: url | append: "/conflicts')" }}
        {% endcapture %}
        {% assign file = exp %}
        </li>{{ file }}
    {% endfor %}
</ul>
