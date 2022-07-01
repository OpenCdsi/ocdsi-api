---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li><a href="https://opencdsi.org/api/vaccines/{{ item.id }}">{{item.id}}</a> {{item.name}}
        <a href="https://opencdsi.org/api/vaccines/{{ item.id }}/antigens/">(Antigens)</a> 
        {% if item.conflicts.length > 0 %}
            <a href="https://opencdsi.org/api/vaccines/{{ item.id }}/conflicts/">(Conflicts)</a> </li>
        {% endif %}
    {% endfor %}
</ul>