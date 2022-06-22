---
title: CDSi Supporting Data API
layout: default
---
The data returned by the **CDSi API** was generated from files located at the [CDC Immunization Information Systems (IIS)](https://www.cdc.gov/vaccines/programs/iis/cdsi.html) site. For a more pleasent browsing experience, try the [JSONView](https://jsonview.com/) extension.

* Schedule Data v4.5
* Testcases v4.4

## Endpoints

* /api/antigens
* /api/antigens/{id}
* /api/antigens/{id}/series
* /api/antigens/{id}/contraindications
* /api/vaccines
* /api/vaccines/{id}
* /api/vaccines/{id}/conflicts
* /api/vaccines/{id}/antigens
* /api/vaccines/groups
* /api/vaccines/groups/{id}
* /api/vaccines/groups/{id}/antigens
* /api/observations
* /api/observations/{id}
* /api/testcases
* /api/testcases/{id}
* /api/testcases/{id}/medical

## Data

### Antigens

{% for id in site.data.api-ids.antigen %}
* [{{id}}](https://opencdsi.org/api/antigens/{{ id }}/)
{% endfor %}

### Vaccines

{% for id in site.data.api-ids.vaccine %}
* [{{id.id}}](https://opencdsi.org/api/vaccines/{{ id.id }}/) {{id.description}}
{% endfor %}

### Vaccine Groups

{% for id in site.data.api-ids.group %}
* [{{id}}](https://opencdsi.org/api/vaccines/groups/{{ id }}/)
{% endfor %}

### Observations

{% for id in site.data.api-ids.observation %}
* [{{id.observationCode}}](https://opencdsi.org/api/observations/{{ id.observationCode }}/) {{id.observationTitle}}
{% endfor %}

### Testcases

{% for id in site.data.api-ids.testcase %}
* [{{id.id}}](https://opencdsi.org/api/testcases/{{ id.id }}/) {{id.name}}
{% endfor %}


