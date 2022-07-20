---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li>
        [{{item.name}}]({{ {{item.id}} | prepend: "vaccine/" | relative_url}})
       <!-- [(Antigens)]({% link '/vaccine/{{ item.id }}/antigens/index.json' %})
        {% assign file = site.static_files | find_exp: "path", "path contains 'vaccine/{{ item.id}}/conflicts'" %}
        {% if file %}
            [(Conflicts)]({% link '{{ file.path }}' %}) -->
            </li>
        {% endif %}
    {% endfor %}
</ul>