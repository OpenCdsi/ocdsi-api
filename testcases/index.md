---
layout: page
title: Testcases
permalink: /testcases/
---

{% assign groups = site.data.api-ids.testcase | group_by: 'group' %}
{% for group in groups %}
<div class="collapsable">
    <input id="{{ group.name }}" class="toggle" type="checkbox">
    <label for="{{ group.name }}" class="lbl-toggle">{{ group.name }}</label>
    <div class="collapsable-content">    
        <ul class="col2">
            {% for item in group.items %}
            {% endfor %}
        </ul>
    </div>
</div>
{% endfor %}
