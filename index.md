---
layout:default
---
## Antigens

{% for id in site.data.api-ids.antigen %}

* [{{id}}](https://opencdsi/api/antigens/{{ id }}/)

{% endfor %}

## Vaccines

{% for id in site.data.api-ids.vaccine %}

* [{{id.id}}](https://opencdsi/api/vaccines/{{ id.id }}/) - {{id.description}}

{% endfor %}

## Vaccine Groups

{% for id in site.data.api-ids.group %}

* [{{id}}](https://opencdsi/api/groups/{{ id }}/)

{% endfor %}

## Observations

{% for id in site.data.api-ids.observation %}

* [{{id.observationCode}}](https://opencdsi/api/observations/{{ id.observationCode }}/) - {{id.observationTitle}}

{% endfor %}

## Testcases

{% for id in site.data.api-ids.testcase %}

* [{{id.id}}](https://opencdsi/api/testcases/{{ id.id }}/) - {{id.name}}

{% endfor %}


