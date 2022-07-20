---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li>
        <a href="{{ page.permalink | append: item.id  | relative_url }}">{{item.name}}</a>
        </li>
    {% endfor %}
</ul>
