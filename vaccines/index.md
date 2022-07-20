---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li><a href="'vaccine/{{ item.id }}' | relative_url">{{item.id}}</a> {{item.name}}
        <a href="'vaccine/{{ item.id }}/antigens' | relative_url">(Antigens)</a> 
        {% assign file = site.static_files | find_exp: "path", "path contains 'vaccine/{{ item.id}}/conflicts'" %}
        {% if file %}
            <a href="{{ file.path }} | relative_url">(Conflicts)</a> </li>
        {% endif %}
    {% endfor %}
</ul>