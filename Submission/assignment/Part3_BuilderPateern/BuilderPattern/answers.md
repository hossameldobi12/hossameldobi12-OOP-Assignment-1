## Task 3.1 — 20-Parameter Constructors

### 1. Why is a constructor with 20 parameters a problem?

A constructor with 20 parameters is hard to read and use.

- It is easy to pass values in the wrong order.
- Some parameters have the same type, so the compiler may not notice the mistake.
- It is hard to know what each value means.
- If we add a new parameter, we may need to change many places in the code.

### 2. Is the problem only the constructor length?

No. The class contains different types of information, such as customer details, addresses, and payment details.

We can put related information in separate classes. This makes the code easier to understand and change. But having 20 properties in one class is not always wrong. It depends on whether they belong together.

## Task 3.3 — Composed Builders

### Why is the composed version better?

**1. Single responsibility**

Each builder has one job:

- `CustomerInfoBuilder` creates customer information.
- `AddressBuilder` creates an address.
- `OrderInfoBuilder` creates order and payment details.
- `InvoiceBuilder` combines everything to create the invoice.

**2. Easier to maintain**

Each part has its own class and builder. If we need to change customer information or address details, we can work on that part without putting everything in one large builder.

**3. Reuse**

We can use the same `AddressBuilder` for both billing and shipping addresses. This avoids writing the same code twice.

**4. Readability**

The builder from Task 3.2 is easier to read than a constructor with 20 parameters, but it still handles all the properties.

In Task 3.3, we use separate builders for customer information, addresses, and order details. The `InvoiceBuilder` only combines these parts to create the final invoice.

**5. Mandatory and optional data**

Mandatory data is passed through constructors. Optional data can be added using methods when needed. For example, the shipping address is optional, while the customer information and billing address are required.

### Conclusion

The composed Builder pattern makes the code easier to read, maintain, and reuse. Each builder has one job, and the `InvoiceBuilder` combines the smaller parts to create the final invoice.