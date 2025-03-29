# EasyER: Emergency Room Scheduler

EasyER is a lightweight emergency room patient management system built with ASP.NET Core 6.0 and Blazor WebAssembly. This full-stack web application manages patient intake, triage, and assignment to medical staff within a hospital emergency department.

## Overview

EasyER automates patient triage based on trauma levels and wait times, allowing medical staff to focus on patient care rather than administrative tasks. The system features a secure role-based authentication system for nurses, doctors, and administrators with tailored interfaces for each role.

## Key Features

- **Automated Patient Triage**: Prioritizes patients based on trauma level and wait time
- **Role-Based Access Control**: Different interfaces for nurses, doctors, and administrators
- **Real-Time Patient Queue**: Displays patients sorted by urgency
- **Doctor-Patient Assignment**: Tracks which doctors are treating which patients
- **Patient Status Tracking**: Follows patients from admission to discharge

## Technology Stack

- **Frontend**: Blazor WebAssembly, Bootstrap
- **Backend**: ASP.NET Core 6.0, Entity Framework Core
- **Authentication**: ASP.NET Identity with JWT tokens
- **Database**: SQL Server
- **Deployment**: Azure Web App

## Architecture

The solution follows a modern client-server architecture:

- **Client**: Blazor WebAssembly SPA offering responsive UI with real-time updates
- **Server**: RESTful API endpoints handling data operations and authentication
- **Database**: Relational database with separate contexts for patients, doctors, and nurses

The application uses a repository pattern to separate data access logic from controllers, making the code more maintainable and testable.

## Project Structure

- **EasyER.Client**: Blazor WebAssembly frontend application
- **EasyER.Server**: ASP.NET Core backend API
- **EasyER.Shared**: Shared models between client and server
- **EasyERTests**: Unit tests for controllers and repositories

## Role-Based Functionality

### Nurses
- Admit new patients
- Update patient information
- View patient queue

### Doctors
- View prioritized patient queue
- Accept patients from queue
- Release patients when treatment is complete

### Administrators
- Create new user accounts for medical staff
- View system-wide statistics
- Manage all patients and staff

## Testing

The system includes comprehensive unit tests using NUnit and Moq, covering:
- Patient controller operations
- Doctor controller operations
- Nurse controller operations
- Repository functionality

## Security

- JWT-based authentication
- Role-based authorization
- Password security with ASP.NET Identity
- HTTPS communication

## Development Details

This project demonstrates my proficiency in:
- Building full-stack applications with ASP.NET Core and Blazor
- Implementing authentication and authorization
- Designing RESTful APIs
- Writing clean, maintainable, and testable code
- Using Entity Framework Core for data access
- Working with SQL Server and migrations
- Applying dependency injection for loosely coupled components
- Testing with NUnit and Moq

## Future Enhancements

- Implement real-time updates with SignalR
- Add patient outcome tracking and reporting
- Develop analytics dashboard for hospital management
- Create mobile application for staff on the move
- Integrate with electronic health record (EHR) systems
  
