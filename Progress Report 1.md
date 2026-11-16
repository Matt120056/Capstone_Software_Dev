# Progress Report 1
## Personal Finance Management System

**Course:** Capstone Project  
**Project Option:** Option A – Personal Finance Management System  
**Students:** Matt pheaton, Priscilla Olohi Eke, Elizabeth Mueni Busy
**Date:** November 16, 2026

---

## 1. Project Selection and Problem Definition

For this capstone project, we have selected **Option A – Personal Finance Management System**. The goal of this project is to develop a C# console application that allows users to manage a personal budget and keep track of their income and expenses.

Many people have difficulty keeping track of where their money goes throughout the month. Recording expenses manually can become confusing, especially when trying to understand how much money is being spent in different categories. This application will provide a simple way to organize financial transactions, monitor spending and understand the user's overall financial position.

The system will allow users to add, view, search, edit and delete financial transactions. Users will also be able to create spending budgets for different categories, such as groceries, transportation, entertainment and housing. The application will calculate total income, total expenses and the remaining balance. It will also identify when spending exceeds a category's budget.

The application will be made using C# in VS. Transaction and budget information will be stored locally using JSON files and the System.Text.Json library. All financial records used during development and testing will be fictional to avoid exposing real personal or financial information.

### Project Objectives

- Create and manage income and expense transactions.
- Organize transactions using supported spending categories.
- Calculate total income, expenses and net balance.
- Allow users to create and manage category budgets.
- Display spending compared to budget limits.
- Provide alerts when a category exceeds its budget.
- Use LINQ to search, filter, sort and summarize financial information.
- Save and reload information using JSON persistence.

## 2. Draft User Stories and Acceptance Criteria

The following six user stories describe the main functionality planned for the application.

### User Story 1 – Add Transactions

**As a user, I want to add income and expense transactions so that I can keep track of my financial activity.**

Acceptance Criteria:
- The user can enter a transaction date, type, category, amount and description.
- Every transaction must have a unique ID.
- The transaction amount must be greater than zero.
- Invalid dates, amounts and unsupported categories must be rejected.
- A successfully entered transaction is added to the transaction list.

### User Story 2 – View Transactions

**As a user, I want to view all my transactions so that I can understand my financial activity.**

Acceptance Criteria:
- The application displays all recorded transactions.
- Each transaction displays its ID, date, type, category, amount and description.
- Transactions can be organized by date.
- The application displays an appropriate message when there are no transactions.

### User Story 3 – Search and Filter Transactions

**As a user, I want to search and filter transactions so that I can find specific financial records.**

Acceptance Criteria:
- The user can filter transactions by income or expense.
- The user can filter transactions by category.
- The user can filter transactions by date.
- The application displays matching results.
- The application displays a message when no matching transactions are found.

### User Story 4 – Edit and Delete Transactions

**As a user, I want to edit or delete transactions so that I can correct mistakes and keep my financial records accurate.**

Acceptance Criteria:
- The user can select a transaction using its unique ID.
- The user can update transaction information.
- Invalid changes are rejected.
- The user can delete an existing transaction.
- The application displays an error if the selected transaction does not exist.

### User Story 5 – Manage Category Budgets

**As a user, I want to set spending budgets for different categories so that I can control my expenses.**

Acceptance Criteria:
- The user can create a budget for a supported category.
- The user can update an existing category budget.
- Budget amounts must be greater than zero.
- The application calculates actual spending for each category.
- The application displays an alert when spending exceeds the budget.

### User Story 6 – View Financial Summaries and Save Data

**As a user, I want to view financial summaries and save my information so that I can understand my financial position and access my information later.**

Acceptance Criteria:
- The application calculates total income.
- The application calculates total expenses.
- The application calculates the net balance.
- Expenses can be grouped by category.
- Transaction and budget information can be saved to JSON files.
- Previously saved information can be loaded when the application restarts.
- Missing, empty or malformed files are handled safely.

## 3. Initial System Design

The application will use a simple object-oriented design with separate classes for data models, business operations, persistence and the console interface.

### Planned Classes

**Transaction**

This class will represent individual financial transactions. It will contain:
- TransactionId
- Date
- Type (Income or Expense)
- Category
- Amount
- Description

**Budget**

This class will represent spending limits for individual categories. It will contain:
- Category
- MonthlyLimit

**FinanceManager**

This class will manage the main financial operations. It will handle adding, editing, deleting and searching transactions. It will also calculate financial summaries and compare expenses against budgets.

**JsonStorage**

This class will manage saving and loading application data using System.Text.Json. It will also handle missing or invalid JSON files.

**ConsoleMenu**

This class will manage the user interface, display the main menu, collect user input and display the results of different operations.

### Collection Choices

The application will use the following data structures:

**List<Transaction>**

A List will store all financial transactions. This is appropriate because the number of transactions will change as users add and delete records. It also allows transactions to be searched, sorted and filtered.

**Dictionary<string, Budget>**

A Dictionary will store budgets using the category name as the key. This allows the application to quickly locate a budget when comparing category spending against its limit.

An array is not necessary for the main transaction records because the number of records is expected to change. A Queue or Stack may be considered for future functionality, but they are not required for the current project because they do not provide a necessary benefit to the planned features.

### Planned LINQ Implementation

LINQ will be used to make searching and processing financial information easier.

The planned operations include:

- **Where():** Filter transactions by category, date or transaction type.
- **OrderByDescending():** Sort transactions from highest to lowest amount.
- **Select():** Extract specific transaction information, such as descriptions or amounts.
- **GroupBy():** Group expenses by category to show spending patterns.
- **Sum():** Calculate total income and expenses.
- **Count():** Count the number of transactions.
- **Average():** Calculate the average transaction amount.

At least five meaningful LINQ queries will be implemented. One calculation will also be completed using both LINQ and a traditional foreach loop to compare the results and demonstrate that both approaches produce the same calculation.

## 4. Project Backlog and Initial Development Plan

The initial product backlog identifies the main tasks required to complete the application.

| ID | Task | Priority |
|---|---|---|
| 1 | Create the C# Visual Studio solution | High |
| 2 | Develop the Transaction class | High |
| 3 | Develop the Budget class | High |
| 4 | Implement transaction management | High |
| 5 | Implement input validation and business rules | High |
| 6 | Implement LINQ calculations and filtering | High |
| 7 | Implement category budget management | High |
| 8 | Implement JSON saving and loading | High |
| 9 | Create and complete test cases | Medium |
| 10 | Prepare README and project documentation | Medium |

### Planned Development Sprints

**Sprint 1 – Initial Setup and Design**

- Create the Visual Studio C# console application.
- Define the project requirements and user stories.
- Create the initial class diagram.
- Develop the main data model classes.
- Implement the basic console menu.

**Sprint 2 – Transaction Management**

- Implement adding and viewing transactions.
- Implement editing and deleting transactions.
- Add input validation and error handling.
- Implement searching and filtering using LINQ.

**Sprint 3 – Budgets and Data Persistence**

- Implement category budgets.
- Calculate spending against budget limits.
- Add over-budget alerts.
- Implement JSON saving and loading.
- Include at least 15 synthetic transactions.

**Sprint 4 – Testing and Final Documentation**

- Complete functional and boundary testing.
- Resolve identified defects.
- Prepare screenshots and console transcripts.
- Complete the README and project documentation.
- Review Git history and contribution records.

### Team Responsibilities

The project will be managed through shared development tasks and Git version control. Responsibilities will be divided based on the team members' contributions and areas of focus.

All team members will participate in reviewing requirements, testing functionality, documenting progress and reviewing the completed application. Individual contributions will be recorded through Git commits and a contribution log.

## 5. Initial Implementation and Development Progress

The initial development phase will focus on creating a working C# console application in Visual Studio.

The first implementation milestone is to establish the project structure and create the main classes required by the system. The initial application will include a basic console menu that allows users to navigate the available options.

The planned main menu will include:

1. Add Transaction
2. View All Transactions
3. Search Transactions
4. Edit Transaction
5. Delete Transaction
6. Manage Budgets
7. View Financial Summary
8. Save and Exit

The application will use at least 15 fictional transactions for demonstration and testing. These records will include different income and expense categories, dates and amounts to allow the LINQ queries and budget calculations to be tested.

JSON persistence will be implemented so that information is retained between application sessions.

## 6. Initial Business Rules

The application will follow several business rules to ensure that financial records remain consistent and accurate.

1. Transaction amounts must always be greater than zero.
2. Each transaction must have a unique ID.
3. Transactions must use a valid date and a supported category.
4. Budgets must have a positive monetary value and be assigned to a supported category.
5. Only expense transactions will count toward category spending limits. Income will be included in financial summaries but will not reduce recorded expenses.

These rules will be validated when users enter or modify information. Boundary cases, such as zero amounts, negative amounts, duplicate IDs and invalid dates, will be included in testing.

## 7. Testing and Verification Plan

Testing will be carried out throughout development to confirm that the application behaves as expected.

The initial testing plan will include:

| Test | Expected Result |
|---|---|
| Add a valid income transaction | Transaction is successfully added |
| Add a valid expense transaction | Transaction is successfully added |
| Enter a negative amount | Application rejects the amount |
| Enter a zero amount | Application rejects the amount |
| Enter a duplicate transaction ID | Application rejects the duplicate |
| Enter an invalid date | Application rejects the date |
| Search for an existing transaction | Matching transaction is displayed |
| Search for a nonexistent transaction | No-results message is displayed |
| Edit an existing transaction | Transaction is updated |
| Delete an existing transaction | Transaction is removed |
| Exceed a category budget | Over-budget alert is displayed |
| Save and reload application data | Previously saved information is restored |

The final project will include at least 12 test cases covering typical use, invalid input, boundary conditions, empty datasets, duplicate records and JSON save/reload functionality.

Screenshots or console transcripts will be collected to demonstrate representative test results. A defect log will also be maintained to document at least three issues discovered during development, how they were resolved and the results of retesting.

## 8. Security and Risk Management

Since this application deals with financial information, privacy and data integrity will be considered during development.

The application will only use synthetic financial records. No real bank accounts, credit card numbers, payment information or personal financial records will be used.

The initial risk register is outlined below.

| Risk | Likelihood | Impact | Mitigation | Owner |
|---|---|---|---|---|
| Invalid financial data entered by users | Medium | High | Validate all input and enforce business rules | Developer |
| JSON file becomes corrupted | Medium | High | Handle exceptions and maintain safe file-loading behaviour | Developer |
| Duplicate transaction records | Medium | Medium | Enforce unique transaction IDs | Developer |
| Accidental deletion of financial records | Medium | High | Confirm deletion and test data persistence | Developer |
| Loss of project work or Git conflicts | Medium | High | Commit regularly and maintain a shared Git repository | All team members |

### AI-Assistance Disclosure

AI tools may be used during development to assist with understanding C# concepts, reviewing code structure, generating initial code examples and identifying possible errors.

Any AI-generated suggestions will be reviewed and tested before being included in the application. The development team will make changes where necessary to ensure the code meets the project requirements and that each team member understands the implemented functionality.

AI assistance will not replace testing, verification or individual contributions. The final implementation, testing results and documentation will be reviewed by the team.

## 9. Conclusion and Next Steps

The Personal Finance Management System has been selected as the project because it provides a practical opportunity to apply object-oriented programming, data structures, LINQ, exception handling and JSON persistence in a real-world scenario.

The initial requirements and six user stories establish the main functionality that the application will provide. The proposed class structure separates the data models, business operations, persistence and console interface to keep the application organized and maintainable.

The next stage will focus on developing the initial working C# application, implementing transaction management and validating user input. After that, budget management, LINQ calculations and JSON persistence will be added.

The overall goal is to deliver a fully functional, well-tested and documented console application that meets the technical requirements of the capstone project.