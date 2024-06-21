# Rental Car Company project

This is a rental car company backend platform powered by .NET 6.

Esta WEB API expone diferentes servicios para la gestión de una empresa de alquiler de autos.

## Getting started

1. Configura el string de conexión a tu base de datos de SQL Server en el archivo `RentalCar.Api.appsettings.Development.json` en la propiedad `ConnectionStrings.SQLServerDatabase`
2. Ejecuta la aplicación utilizando VS2022. Esta creará automáticamente la base de datos, su estructura y completará las diferentes tablas con registros fake. Esto es así solo por propósito de testing y para cumplir con la consigna. No debería ser de esta forma en un ambiente real.

## Users

### 1. Admin

```json
{
  "email": "martamartinez@example.com",
  "password": "string"
}
```

### 2. Customer

```json
{
  "email": "juanperez@example.com",
  "password": "string"
}
```

## Endpoints

### POST/ company-auth/login

It is an `allow anonymous` endpoint.
Retrieves `CompanyUser` information and its JWT.

### POST/ customers-auth/registration

It is an `allow anonymous` endpoint.
It is `CustomerUser` signup service. Validates that email is not taken by another `CustomerUser` and validates that the date of birth is possible.

### POST/ customers-auth/login

It is an `allow anonymous` endpoint.
Retrieves `CustomerUser` information and its JWT. Validates that `CustomerUser` is active.

### GET/ car-brands

It is an `allow anonymous` endpoint.
Retrieves every registered `CarBrand` ordered alphabetically.

### GET/ countries

It is an `allow anonymous` endpoint.
Retrieves every registered `Country` ordered alphabetically.

### POST/ cars

It is an `authenticated` endpoint.
User should have `VEHICLE_ADD` permission which is provided to `ADMIN` users only.
This endpoint adds a new car<br>

#### Validations:

- `NumberPlate` must not be taken.
- `DailyPrice` should be greater than zero.

#### Behaviour:

- If `UseDefaultCalendar` is set as `true`: it makes the calendar available for the car from the registration date until 30 consecutive days inclusive.
- If `UseDefaultCalendar` is set as `false`: you should provide `AvailableFromDate` and `AvailableToDate` to create car calendar availability. The maximum number of allowed days is 100.

#### More details:

- Its handler uses an `Stored Procedure` with a `CTE` to create calendar avoiding a large in memory loop.

### GET/ cars

It is an `allow anonymous` endpoint.
Retrieves every registered `Car` which is available between provided date range in specified country. It works with pagination.
Besides, `Car` should be active to be in this list.

### GET/ cars/{id}

It is an `allow anonymous` endpoint.
Retrieves a `Car` by ID including its future available dates. If `Car` is not active it will return an exception.

### DELETE/ cars/{id}

It is an `authenticated` endpoint.
User should have `VEHICLE_REMOVE` permission which is provided to `ADMIN` users only.
It marks a `Car` as inactive.

#### Behaviour:

- It does not cancel current or upcoming reservations. The car will simply not be visible for future reservations.

### DELETE/ customers/{id}

It is an `authenticated` endpoint.
User should have `CUSTOMER_REMOVE` permission which is provided to `ADMIN` users and `CUSTOMER` users.
An `ADMIN` could mark as inactive any customer. Customer could mark as inactive only itself.

#### Behaviour:

- It will be successful only if `Customer` does not have current or upcoming reservations.

### POST/ rentals/reservation

It is an `authenticated` endpoint.
User should have `RENTAL_ADD` permission which is provided to `CUSTOMER` users only.
It makes a "pre-reservation" for provided `Car` between provided dates range only for five minutes.

#### Validations:

- `Customer` must be active.
- `Car` must be active.
- Customer's age should be greater or equal than car's country minimum age to drive a car.

#### More details:

- It applies an `Optimistic locking` pattern to avoid race conditions.

### POST/ rentals/confirmation

It is an `authenticated` endpoint.
User should have `RENTAL_ADD` permission which is provided to `CUSTOMER` users only.
It makes a reservation for provided `Car` between provided dates range.

#### Validations:

- `Customer` must have "pre-reserved" the dates using previous endpoint `POST/ rentals/reservation`

#### More details:

- It applies an `Optimistic locking` pattern to avoid race conditions.

### PUT/ rentals/{id}/cancellation

It is an `authenticated` endpoint.
User should have `RENTAL_CANCEL` permission which is provided to `CUSTOMER` users and `ADMIN` users.
It cancels a future reservation and put the `Car` as available between reservation dates range.

### PUT/ rentals/{id}/return

It is an `authenticated` endpoint.
User should have `RENTAL_RETURN` permission which is provided to `ADMIN` users only.
It registers the return of a `Car` in the end or during reservation dates range.
It marks reservation as `FINISHED`.

## Next steps

- Create, design and apply a business rule that sets minimum `Customer` user's age.
- Endpoint to create new calendar dates for an existing `Car`.
- Create, design and apply a business rule that sets what to do when a `Car` is mark as inactive and it has current or upcoming reservations.
- Checkout process in `POST/ rentals/confirmation`. Example: payments, notifications, events.
- Create, design and apply a business rule that sets conditions and policies of cancellation.
- Create, design and apply a business rule to split `FINISHED` reservation status considering if `Car` was returned after or before reservation's end date.
