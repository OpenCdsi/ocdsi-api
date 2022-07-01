---
layout: page
title: Vaccines
permalink: /vaccines/
sort: 2
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li><a href="{{ item.id }}">{{item.id}}</a> {{item.name}}
        <a href="{{ item.id }}/antigens/">(Antigens)</a> 
        {% if item.conflicts.length > 0 %}
            <a href="{{ item.id }}/conflicts/">(Conflicts)</a> </li>
        {% endif %}
    {% endfor %}
</ul>
