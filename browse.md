---
layout:default
---
# Antigens

{% for id in site.data.api-ids.antigen %}
* [{{id}}](https://opencdsi/api/antigens/{{ id }}/)
{% endfor %}

# Vaccines

{% for id in site.data.api-ids.vaccine %}
* [{{id.description}}](https://opencdsi/api/vaccines/{{ id.id }}/)
{% endfor %}

# Vaccine Groups

{% for id in site.data.api-ids.group %}
* [{{id}}](https://opencdsi/api/groups/{{ id }}/)
{% endfor %}

# Observations

{% for id in site.data.api-ids.observation %}
* [{{id.observationCode}} - {{id.observationTitle}}](https://opencdsi/api/observations/{{ id.observationCode }}/)
{% endfor %}

# Testcases

{% for id in site.data.api-ids.testcase %}
* [{{id.id}} - {{id.name}}](https://opencdsi/api/testcases/{{ id.id }}/)
{% endfor %}


