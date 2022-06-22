---
layout:default
---
# Antigens
<ul>
  {% for id in site.data.api-ids.antigen %}
  <li>
    <a href="https://opencdsi/api/antigen/{{ id }}/">{{id }}</a>
  </li>
{% endfor %}
</ul
