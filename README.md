# To-Do List Application

This project is a to-do list application built with Vue 3 for the frontend and .NET Web API for the backend, using SQL Server as the database. The application is a reimagined version of the [Microsoft Edge demo to-do app](gehttps://microsoftedge.github.io/Demos/demo-to-do/), with a focus on improving the user interface (UI) and user experience (UX).

## Architecture
The project is structured using the Domain-Driven Design (DDD) approach. This architecture separates the business logic, data, and presentation layers, ensuring the application is maintainable, scalable, and robust.

## Frontend
- **Technology:** Vue 3, Bootstrap 5.
- **Description:** The user interface is developed with Vue 3 to create a smooth and efficient single-page application (SPA). Bootstrap 5 is used for styling, ensuring a responsive and modern design across various devices.

## Backend
- **Technology:** .NET Web API.
- **Description:** The backend handles all requests from the frontend, manages the business logic, and interacts with the database. The DDD architecture organizes the codebase into distinct layers: Domain, Application, Infrastructure, and API.
- **Database:** SQL Server.

## Key Features
### Main Page
- **Create New To-Do:** Users can create a new task with three inputs: name, deadline date, and priority (important | to-do | optional).
- **Limited Lists:** The "Ongoing" and "Completed" lists on the main page display a maximum of 5 items each.
- **"Show More..." Button:** At the bottom of each list, a "Show more..." button navigates users to the full lists:
  - "Ongoing" list -> `/ongoing` page
  - "Completed" list -> `/completed` page

### Detailed Pages
- **/ongoing and /completed Pages:**
  - **Task Grid:** Both pages display a grid of all tasks for their respective categories.
  - **Task Details:** Each task includes a GUID, name, created date, deadline date, and priority.
  - **Search:** Users can search tasks by name.
  - **Sort:** Tasks can be sorted by priority or deadline date.
  - **Expired Tasks:** On the `/ongoing` page, tasks that have passed their deadline are visually marked as expired.

## Getting Started
### Prerequisites
- Node.js and npm
- .NET SDK
- SQL Server

### Instructions
**Backend:**
- Configure your SQL Server connection string in the `appsettings.json` file.
- Run the necessary database migrations to set up the schema.
- Start the backend application using Visual Studio or the command line.

**Frontend:**
- Navigate to the frontend directory in your terminal.
- Install dependencies: `npm install`.
- Run the application: `npm run dev`.
