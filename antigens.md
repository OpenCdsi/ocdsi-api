---
layout: page
title: Antigens
permalink: /antigens/
---

<ul class="col6">
    {% for item in site.data.api-ids.antigen %}
    <li><a href="https://opencdsi.org/api/antigens/{{ item.id }}/">{{ item.name }}</a>
    <a href="https://opencdsi.org/api/antigens/{{ item.id }}/series">(Series)</a>
    <a href="https://opencdsi.org/api/antigens/{{ item.id }}/contraindications">(Contraindications)</a></li>
    {% endfor %}
</ul>