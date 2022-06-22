---
layout: default
---

## Antigens

{% for id in site.data.api-ids.antigen %}

* [{{id}}](https://opencdsi.org/api/antigens/{{ id }}/)

{% endfor %}

## Vaccines

{% for id in site.data.api-ids.vaccine %}

* [{{id.id}}](https://opencdsi.org/api/vaccines/{{ id.id }}/) - {{id.description}}

{% endfor %}

## Vaccine Groups

{% for id in site.data.api-ids.group %}

* [{{id}}](https://opencdsi.org/api/groups/{{ id }}/)

{% endfor %}

## Observations

{% for id in site.data.api-ids.observation %}

* [{{id.observationCode}}](https://opencdsi.org/api/observations/{{ id.observationCode }}/) - {{id.observationTitle}}

{% endfor %}

## Testcases

{% for id in site.data.api-ids.testcase %}

* [{{id.id}}](https://opencdsi.org/api/testcases/{{ id.id }}/) - {{id.name}}

{% endfor %}


