---
layout: page
title: Antigens
permalink: /antigens/
sort: 1
---

<ul class="col6">
    {% for item in site.data.api-ids.antigen %}
    <li><a href="{{ item.id }}/">{{ item.name }}</a>
    <a href="{{ item.id }}/series">(Series)</a>
    <a href="{{ item.id }}/contraindications">(Contraindications)</a></li>
    {% endfor %}
</ul>
