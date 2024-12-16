# norway-weather-alerts

Full Stack Application that shows the weather alerts for Norway

## WorkerService

The data was fetched from this Public API: [MetAlerts API](https://api.met.no/weatherapi/metalerts/2.0/documentation#%2Fcurrent_-_show_active_alerts)

Not all properties were mapped to the database. The job runs hourly and on the full hour, so 16:00, 17:00, etc.

## WebAPI

The WebAPI will be available on the [localhost:5000](http://localhost:5000)

There are two routes in the entire API that accepts the filtering options.
[/api/weatheralert](http://localhost:5000/api/weatheralert) : For getting the search results.
[/api/weatheralert/filters](http://localhost:5000/api/weatheralert/filters) : For getting the filter options.
The filter options are EventType, Severity, Certainty, RiskMatrixColor and GeographicDomain.

## Frontend
