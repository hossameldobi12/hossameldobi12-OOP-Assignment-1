# Code Design Critique

## 1. Global State

The program uses global arrays and counters that can be accessed and modified by different functions. This makes it difficult to control the data and track where changes happen.

**Solution:**

Each class should own its related data and provide methods to manage it. For example, `Customer` should manage customer data, `Product` should manage product data, and `Order` should manage order data. This makes the code easier to maintain and understand.

## 2. Parallel Arrays and Separated Data and Behavior

The program stores related data in separate arrays, while the functions that manage this data are defined separately. This makes the code harder to maintain because we must keep the arrays synchronized, and the data may become inconsistent if an operation fails.

**Solution:**

We should use classes to group related data and behavior together. This makes the code more organized, easier to maintain, and less prone to errors.

## 3. Multiple Responsibilities

Some functions handle multiple responsibilities instead of focusing on one clear task. For example, a function may validate data, modify arrays, update counters, and display error messages.

This makes the code harder to maintain and test because changing one responsibility may affect other parts of the function.

**Solution:**

We should separate responsibilities into smaller functions or appropriate classes, so each part has a clear purpose.

