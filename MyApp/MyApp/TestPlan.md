# Manual Test Plan

| ID | Test Name | Steps | Expected Result |
| --- | --- | --- | --- |
| TC-001 | Display seeded products | 1. Launch the application. 2. Navigate to `/Productos`. | The index page lists the five seeded sample products with correct details. |
| TC-002 | Create product validation | 1. Navigate to `/Productos/Create`. 2. Submit the form without filling any fields. | Validation messages indicate that Name and SKU are required and the product is not created. |
| TC-003 | Create product success | 1. Navigate to `/Productos/Create`. 2. Fill valid values for Name, SKU, and Stock. 3. Submit the form. | The user is redirected to the index page and the new product appears in the list. |
| TC-004 | Prevent negative stock | 1. Navigate to `/Productos/Create`. 2. Enter a negative number in Stock. 3. Submit the form. | Validation message states that stock quantity cannot be negative and the product is not saved. |
| TC-005 | Edit product details | 1. From the index page, click Edit on an existing product. 2. Update the stock value. 3. Save changes. | The index page shows the updated stock for the product. |
| TC-006 | Delete product | 1. From the index page, click Delete on an existing product. 2. Confirm deletion. | The product is removed from the list and no longer appears on the index page. |
