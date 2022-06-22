---
title: CDSi Supporting Data
layout: default
---
The data returned by the **CDSi API** was generated from files located at [https://www.cdc.gov/vaccines/programs/iis/cdsi.html]. 

* Schedule Data v4.5
* Testcases v4.4

## Antigens

- /api/antigens
- /api/antigens/{id}
- /api/antigens/{id}/series
- /api/antigens/{id}/contraindications
---

{% for id in site.data.api-ids.antigen %}
* [{{id}}](https://opencdsi.org/api/antigens/{{ id }}/)
{% endfor %}

## Vaccines

- /api/vaccines
- /api/vaccines/{id}
- /api/vaccines/{id}/conflicts
- /api/vaccines/{id}/antigens


{% for id in site.data.api-ids.vaccine %}
* [{{id.id}}](https://opencdsi.org/api/vaccines/{{ id.id }}/) - {{id.description}}
{% endfor %}

## Vaccine Groups

- /api/vaccines/groups
- /api/vaccines/groups/{id}
- /api/vaccines/groups/{id}/antigens


{% for id in site.data.api-ids.group %}
* [{{id}}](https://opencdsi.org/api/vaccines/groups/{{ id }}/)
{% endfor %}

## Observations

- /api/observations
- /api/observations/{id}


{% for id in site.data.api-ids.observation %}
* [{{id.observationCode}}](https://opencdsi.org/api/observations/{{ id.observationCode }}/) - {{id.observationTitle}}
{% endfor %}

## Testcases

- /api/testcases
- /api/testcases/{id}
- /api/testcases/{id}/medical


{% for id in site.data.api-ids.testcase %}
* [{{id.id}}](https://opencdsi.org/api/testcases/{{ id.id }}/) - {{id.name}}
{% endfor %}


