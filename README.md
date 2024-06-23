# Rental Car Company project

This is a rental car company backend platform powered by .NET 6.

This WEB API exposes various services for managing a car rental company.

## Getting started

1. Configure the connection string to your SQL Server database in the `RentalCar.Api.appsettings.Development.json` file under the `ConnectionStrings.SQLServerDatabase` property.
2. Run the application `RentalCar.Api` using VS2022. This will automatically create the database -if not exists-, its structure, and populate the different tables with fake records. This is only for testing purposes and to meet the requirements. It should not be done this way in a real environment. Database seeders will create different users and its permissions (See `Users` section).
3. Swagger will be available on `http://localhost:7104/swagger/index.html`.

## Architecture

This is a `Vertical Slices architecture` based on an approach to `Clean architecture` where the goal is the separation of responsibilities (using the `CQRS` pattern) and inverse dependency injection across the different layers that make up the solution: `Presentation`, `Infrastructure`, `Application`, and `Domain`.

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
- This is the "pre-reservation" step. On next step, user will confirm its reservation (checkout).

### POST/ rentals/confirmation

It is an `authenticated` endpoint.
User should have `RENTAL_ADD` permission which is provided to `CUSTOMER` users only.
It confirms the "pre-reservation" which was done by the user in previous step. It is the "checkout" step.

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

### POST/ company-users/login

It is an `allow anonymous` endpoint.
Retrieves `CompanyUser` information and its JWT.

### POST/ customers/registration

It is an `allow anonymous` endpoint.
It is `CustomerUser` signup service. Validates that email is not taken by another `CustomerUser` and validates that the date of birth is possible.

### POST/ customers/login

It is an `allow anonymous` endpoint.
Retrieves `CustomerUser` information and its JWT. Validates that `CustomerUser` is active.

### DELETE/ customers/{id}

It is an `authenticated` endpoint.
User should have `CUSTOMER_REMOVE` permission which is provided to `ADMIN` users and `CUSTOMER` users.
An `ADMIN` could mark as inactive any customer. Customer could mark as inactive only itself.

#### Behaviour:

- It will be successful only if `Customer` does not have current or upcoming reservations.

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

## Tests

1. Run `dotnet test` to execute unit tests
