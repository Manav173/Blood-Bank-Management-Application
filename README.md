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

- [**.NET 8.0 SDK**](https://dotnet.microsoft.com/download)
- Any API testing tool (e.g., [Postman](https://www.postman.com/), [Swagger](https://swagger.io/))

---

## How to Run

1. Clone the repository.

   ```bash
   git clone https://github.com/Manav173/Blood-Bank-Management-Application.git
   
2. Open the Folder in File Explorer.
   
3. Open the "Blood Bank Management Application.sln" file with Microsoft Visual Studio 2022.
   
4. At the top center click on the "https" button to open it in the default browser.

---

# Screenshots of Both SWAGGER and POSTMAN

## 1. Get All Entries.

![GetAllEntries Swagger](https://github.com/user-attachments/assets/e3913f5c-9cb6-4929-aa25-da98117632e2)

<img alt="GetAllEntries Postman" src="https://github.com/user-attachments/assets/498a6ebd-4383-4563-a20e-dc7fb85ec299">

---

## 2. Add An Entry.

![AddAnEntry Swagger](https://github.com/user-attachments/assets/9f05b8dc-f4eb-4a1e-b337-c24b8cc29958)

<img alt="AddAnEntry Postman" src="https://github.com/user-attachments/assets/f3078aad-5341-482d-ba57-b48e4afd562e">

Updated Database.

<img alt="AddAnEntry Result" src="https://github.com/user-attachments/assets/ad572e35-4846-4170-875f-43a153d32db5">

---

## 3. Get An Entry By Id.

![GetAnEntry Swagger](https://github.com/user-attachments/assets/b1541b86-ca24-488f-9a2d-7802244df18a)

<img alt="GetAnEntry Postman" src="https://github.com/user-attachments/assets/edf90a61-7e78-46f7-8ace-ee26e57fba06">

---

## 4. Update An Entry By Id.

Updated Age, Collection Date, Expiration Date and Status.

![UpdateAnEntry Swagger](https://github.com/user-attachments/assets/8c2a2a8d-3cb0-416f-a7fc-55425bb0a164)

Updated Database.

![UpdateAnEntry Swagger Result](https://github.com/user-attachments/assets/01dd8111-046d-47ed-80ca-e2f3b04a6e4f)

Updated Name and Blood Type.

<img alt="UpdateAnEntry Postman" src="https://github.com/user-attachments/assets/7733f8ef-0309-4cd3-9f9f-e08951622f55">

Updated Database.

<img alt="UpdateAnEntry Postman Result" src="https://github.com/user-attachments/assets/5a6f6d74-48b8-4456-a48e-e41ed335ac91">

---

## 5. Delete An Entry By Id.

![DeleteAnEntry Swagger](https://github.com/user-attachments/assets/2410d13a-f2c2-488b-8ea0-923885df49fd)

<img alt="DeleteAnEntry Postman" src="https://github.com/user-attachments/assets/12fc7cb1-9455-459a-ab96-d4aaa3a0b782">

---

## 6. Pagination.

![Pagination Swagger](https://github.com/user-attachments/assets/14bd55b1-9a03-475b-84be-1fc8c06789b1)

<img alt="Pagination Postman" src="https://github.com/user-attachments/assets/e68f351a-4a56-4403-be7c-430e2aa9a9c2">

---

## 7. Search By Blood Type.

![SearchByBloodType Swagger](https://github.com/user-attachments/assets/ed1defca-3f7f-4f6a-94e9-61e4a3a32f98)

<img alt="SearchByBloodType Postman" src="https://github.com/user-attachments/assets/650f1479-46a9-43a4-9091-2bedd3bed119">

---

## 8. Search By Status

![SearchByStatus Swagger](https://github.com/user-attachments/assets/c29a2ebf-b816-4485-9af2-de3691b756b6)

<img alt="SearchByStatus Postman" src="https://github.com/user-attachments/assets/6b17441b-6b24-49a9-a1b3-a503911b2e30">

---

## 9. Search By Donor Name.

![SearchByDonorName Swagger](https://github.com/user-attachments/assets/5ef19bf5-c04d-4a6b-9446-612df96a0458)

<img alt="SearchByDonorName Postman" src="https://github.com/user-attachments/assets/bb027c12-3ca4-43b7-b422-2c795b3f97b9">

---

## 10. Filter Entries.

![FilterEntries Swagger](https://github.com/user-attachments/assets/63d0f7d2-d09d-416b-b571-b58049e86b12)

<img alt="FilterEntries Postman" src="https://github.com/user-attachments/assets/8e840043-50a5-4a64-957d-bd144f1daa9f">

---

## 11. Sort Entries.

![SortEntries Swagger](https://github.com/user-attachments/assets/9333755a-9cfd-4f01-9ac0-688b55c5dff4)

<img alt="SortEntries Postman" src="https://github.com/user-attachments/assets/9da0fd69-eac3-405f-a81c-81aff1192812">

