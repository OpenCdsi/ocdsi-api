# CDSi API
The data returned by these endpoints was generated from files located at https://www.cdc.gov/vaccines/programs/iis/cdsi.html. 

* Schedule Data v4.5
* Testcases v4.4

## API Endpoints

### Antigen Supporting Data
* /api/antigens
* /api/antigens/{id}
* /api/antigens/{id}/series
* /api/antigens/{id}/contraindications

### Schedule Supporting Data - Vaccines
* /api/vaccines
* /api/vaccines/{id}
* /api/vaccines/{id}/conflicts
* /api/vaccines/{id}/antigens
* /api/vaccines/groups
* /api/vaccines/groups/{id}
* /api/vaccines/groups/{id}/antigens

### Schedule Supporting Data - Observations
* /api/observations
* /api/observations/{id}

### Testcase Supporting Data
* /api/testcases
* /api/testcases/{id}
* /api/testcases/{id}/medical

## Jekyll Support
* /_data/api-ids/antigen.json
* /_data/api-ids/vaccine.json
* /_data/api-ids/group.json
* /_data/api-ids/observation.json
* /_data/api-ids/testcase.json

