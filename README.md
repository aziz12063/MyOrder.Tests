# MyOrderClient

**MyOrderClient** is a Blazor Hybrid app built on .NET 8, currently focused on server-side functionality. The app integrates with IIS for Windows Authentication, automatically including the authenticated user's name in HTTP requests to backend services.

## Introduction 

This application is to be used internally by Raja's commercial agents to process orders.

## Key Features

- **Blazor Hybrid**: Primarily server-side, with future plans for more client-side interactivity.
- **IIS Authentication**: Handles Windows Authentication and includes the username in HTTP headers automatically.
- **Refit**: Used for making clean and efficient API calls.
- **Polly**: Adds resiliency with retry and fallback mechanisms.
- **Flux/Redux Pattern**: Manages application state predictably and consistently.

## Development Notes

- **IIS Configuration**: Ensure that Windows Authentication is enabled and correctly configured:
  - **Disable Anonymous Authentication**: Ensure that Anonymous Authentication is disabled to enforce secure access.
  - **Enable Windows Authentication**: Enable Windows Authentication and configure it to use only:
    - **Negotiate**: This is the preferred authentication method, using Kerberos where available.
    - **NTLM**: This acts as a fallback if Kerberos is not available.
  - Make sure that the application pool is configured to use .NET 8 and is correctly associated with the app.

- **Refit**: We’re using Refit for making API calls. It simplifies the codebase by allowing us to define interfaces for our API interactions, making the code cleaner and easier to maintain.

- **Polly**: Integrated with Refit, Polly handles retry logic and fallback mechanisms to make our API calls more resilient in case of transient failures.

- **State Management**: Following the Flux/Redux pattern ensures that our application state is predictable and manageable as the app grows and more features are added.

## Build and Test

This section is currently under development and will be updated once the build and testing process is finalized. Please check back later for more detailed instructions.

## Contributing

Internal team only. Create a branch, commit, and submit a pull request when ready. Preferably, use Kanban boards and manage issues in Azure DevOps to keep track of progress and tasks.

## License

Proprietary - Internal use only.