# StudentCourseManager
Project Structure
The project is organized into the following components:

Controllers: There are five controllers available:

Student: Handles CRUD operations for managing student data.
Course: Handles CRUD operations for managing course data.
StudentCourse: Handles CRUD operations for managing the relationship between students and courses. This table serves as an intermediate table due to the many-to-many relationship between students and courses.
Users: Handles CRUD operations for managing user information. Only users with the admin role can modify data in this table.
Login: Provides a mechanism for user authentication.
DDD Principles: The project adheres to Domain-Driven Design (DDD) principles, which emphasize structuring the codebase around business domains and maintaining a clear separation of concerns.

CQRS Pattern: The Command Query Responsibility Segregation (CQRS) pattern is used to separate read and write operations, allowing for better scalability and performance optimization.

Authentication and Authorization: The project implements a secure authentication system that ensures only authenticated users can access certain resources. Additionally, it includes role-based authorization to restrict specific actions to privileged users.

##Getting Started
To run this project locally, follow these steps:

Clone the repository from GitHub:

1. git clone https://github.com/Xayal02/StudentCourseManager
2. Install the required dependencies listed in the project's documentation.
3. Configure the necessary environment variables for database connection and other settings.
4. Build the project using the provided build command or IDE-specific build options.
