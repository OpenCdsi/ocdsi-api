---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li><a href="https://opencdsi.org/api/vaccines/{{ item.id }}">{{item.id}}</a> {{item.name}}
        <a href="https://opencdsi.org/api/vaccines/{{ item.id }}/antigens/">(Antigens)</a> 
        {% assign file = site.static_files | find_exp: "path", "path contains '{{ item.id }}/conflicts'" %}
        {% if file %}
            <a href="{{ file.path  | absolute_url }}">(Conflicts)</a> </li>
        {% endif %}
    {% endfor %}
</ul>