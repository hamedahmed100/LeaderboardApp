**Application: Team Step Leaderboard**

**Overview**

This application provides an API for tracking and managing step counts for teams of employees. It leverages a .NET Core backend to handle data storage and retrieval, and exposes RESTful endpoints to interact with the data.

**Features**

* **Team Management:**
    * Create new teams
    * Delete existing teams
    * Retrieve a list of all teams

* **Counter Management:**
    * Create new counters for a specific team
    * Delete existing counters
    * Retrieve a list of all counters for a team

* **Step Tracking:**
    * Increment the value of a counter to record steps
    * Retrieve the total step count for a team
    * Retrieve a list of all teams and their total step counts

**API Endpoints**

**Teams**

* **GET /api/Teams:** Retrieves a list of all teams
* **POST /api/Teams:** Creates a new team
* **GET /api/Teams/{teamId}:** Retrieves a specific team
* **DELETE /api/Teams/{teamId}:** Deletes a specific team

**Counters**

* **POST /api/Teams/{teamId}/counters:** Creates a new counter for a specific team
* **DELETE /api/Teams/counters/{counterId}:** Deletes a specific counter
* **POST /api/Teams/counters/{counterId}/increment:** Increments the value of a specific counter
