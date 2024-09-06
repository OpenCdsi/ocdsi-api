---
title: Home
layout: default
---

{%- assign versions = site.data['metadata'] -%}

### Versions

- Logic Spec v{{ versions.specification.version }}
- Schedule Data v{{ versions.supportingData.version }}
- Testing Cases v{{ versions.testcaseData.version }}

### Available Endpoints

- /v2/antigens/
- /v2/antigens/catalog/
- /v2/antigens/*antigen-key*/
- /v2/antigens/*antigen-key*/series/
- /v2/antigens/*antigen-key*/series/*series-key*/
- /v2/vaccines/
- /v2/vaccines/catalog/
- /v2/vaccines/*cvx*/
- /v2/vaccines/*cvx*/livevirusconflicts/
- /v2/observations/
- /v2/observations/catalog/
- /v2/observations/*observation-code*/
- /v2/groups/
- /v2/groups/*vaccine-group*/
- /v2/groups/*vaccine-group*/antigens/
- /v2/cases/
- /v2/cases/catalog/
- /v2/cases/assessments/
- /v2/cases/*case-id*/
- /v2/cases/*case-id*/assessment/
