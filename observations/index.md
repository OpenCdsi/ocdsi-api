---
layout: page
title: Observations
permalink: /observations/
---

{% assign items = site.data.api-ids.observation | where: 'indicated', 'true' %}
<div class="collapsable">
    <input id="collapsible" class="toggle" type="checkbox">
    <label for="collapsible" class="lbl-toggle">Indicated</label>
    <div class="collapsable-content">
        <ul class="col2">
            {% for item in items %}
            <!-- <li>[{{item.name}}]({% link "{{ item.id }}/index.json" %})</li> -->
            {% endfor %}
        </ul>   
    </div>
</div>

{% assign items = site.data.api-ids.observation | where: 'contraindicated', 'true' %}
<div class="collapsable">        
    <input id="collapsible2" class="toggle" type="checkbox">
    <label for="collapsible2" class="lbl-toggle">Contraindicated</label>
    <div class="collapsable-content">
        <ul class="col2">
            {% for item in items %}
            <!-- <li><a href="{{ item.id }}/">{{item.id}}</a>
                {{item.name}}</li> -->
            {% endfor %}
        </ul>
    </div>
</div>