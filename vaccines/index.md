---
layout: page
title: Vaccines
permalink: /vaccines/
---

<ul class="col2">
    {% for item in site.data.api-ids.vaccine %}
        <li>
        [{{item.name}}]({{ "vaccine/" | append: {{item.id}}  | relative_url}})
   
        </li>
    {% endfor %}
</ul>
