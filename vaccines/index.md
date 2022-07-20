---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li>
        <a href="{{ page.permalink | append: item.id  | relative_url }}">{{item.name}}</a>
        <a href="{{ page.permalink | append: item.id | append: '/antigens'  | relative_url }}">(Antigens)</a>
        </li>
    {% endfor %}
</ul>
