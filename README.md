# Blood Bank Management Application

This application provides a RESTful API for managing blood bank entries, allowing users to perform CRUD operations, search, filter, sort, and paginate data. It is built using ASP.NET Core and serves as a backend service for managing blood donor records.

---

## Features

1. **CRUD Operations**
   - **Get All Entries:** Retrieve a list of all blood bank entries.
   - **Get Entry by ID:** Retrieve a specific entry by its ID.
   - **Add New Entry:** Add a new blood bank entry with automatic status assignment.
   - **Update an Entry:** Update an existing blood bank entry by ID.
   - **Delete an Entry:** Delete an entry from the list by ID.

2. **Search**
   - Search blood bank entries by **Blood Type**, **Status**, or **Donor Name**.

3. **Filter**
   - Filter entries based on criteria like blood type, status, age range, quantity range, collection date range, and expiration date range.

4. **Sorting**
   - Sort entries by properties such as **Blood Type**, **Age**, **Quantity**, **Collection Date**, or **Expiration Date** in ascending or descending order.

5. **Pagination**
   - Retrieve a specific page of entries with a customizable page size.

---

## API Endpoints

### Base URL: `/api/BloodBank`

| HTTP Method | Endpoint                  | Description                                   |
|-------------|---------------------------|-----------------------------------------------|
| **GET**     | `/`                       | Retrieve all blood bank entries.              |
| **GET**     | `/{id}`                   | Retrieve an entry by ID.                      |
| **POST**    | `/`                       | Add a new blood bank entry.                   |
| **PUT**     | `/{id}`                   | Update an entry by ID.                        |
| **DELETE**  | `/{id}`                   | Delete an entry by ID.                        |
| **GET**     | `/page`                   | Retrieve paginated blood bank entries.        |
| **GET**     | `/search/byBloodType`     | Search entries by blood type.                 |
| **GET**     | `/search/byStatus`        | Search entries by status.                     |
| **GET**     | `/search/byDonorName`     | Search entries by donor name.                 |
| **GET**     | `/filter`                 | Filter entries based on multiple criteria.    |
| **GET**     | `/sort`                   | Sort entries by a specified property.         |

---

## How Status is Determined

- **Requested**: If the collection date is in the future.
- **Expired**: If the expiration date has passed.
- **Available**: If the collection and expiration dates are valid for current availability.

---

## Sorting Guide

- The `sortby` parameter specifies the property to sort by (e.g., `BloodType`, `Age`, `Quantity`, etc.).
- The `sortorder` parameter determines the sorting order:
  - `asc`: Ascending
  - `desc`: Descending
- **Example**: `/sort?sortby=Age&sortorder=desc`

---

## Filtering Guide

You can apply multiple filters by including them as query parameters. **Supported filters**:

- `bloodType` (e.g., `A+`, `O-`)
- `status` (e.g., `Available`, `Expired`, `Requested`)
- `minAge` / `maxAge`
- `minQuantity` / `maxQuantity`
- `minCollectionDate` / `maxCollectionDate`
- `minExpirationDate` / `maxExpirationDate`

---

## Prerequisites

- [**.NET 6.0 SDK**](https://dotnet.microsoft.com/download)
- Any API testing tool (e.g., [Postman](https://www.postman.com/), [Swagger](https://swagger.io/))

---

## How to Run

1. Clone the repository.
2. Navigate to the project directory.
3. Build and run the application using:
   ```bash
   dotnet run
4. Access the API at https://localhost:<port>/api/BloodBank.

---
