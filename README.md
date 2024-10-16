# NimoInfotech Project

This project is built using ASP.NET Core and utilizes Entity Framework Code First to manage the database. The database is named **NimoInfotech**.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Running the Project](#running-the-project)
- [Database Setup](#database-setup)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Requirements

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)
- [SQL Server Express or any other SQL Server version](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation

1. Clone this repository to your local machine using:
   ```bash
   git clone https://github.com/amin1063/NimoInfotech.git
   ```
2. Navigate to the project directory:
   ```bash
   cd nimo-infotech
   ```
3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```

## Running the Project

1. Open the project in Visual Studio or your preferred IDE.
2. Ensure the correct project is set as the startup project.
3. Run the following command to apply any pending migrations and update the database:
   ```bash
   dotnet ef database update
   ```
4. Start the application:
   - In Visual Studio, press `F5` or click on the "Start" button.
   - Alternatively, you can run:
     ```bash
     dotnet run
     ```
5. Open your web browser and navigate to `https://localhost:7072` to view the application.

## Database Setup

The application uses Entity Framework Code First, which means the database will be created automatically based on the models defined in your project. 

### Initial Migration

To create the initial migration for the database, run the following command:
```bash
dotnet ef migrations add InitialCreate
```

Then, update the database to apply the migration:
```bash
dotnet ef database update
```

## Usage

Once the application is running, you can access the following features:

- **Category Management**: Add, edit, and delete categories.
- **Product Management**: Add, edit, and delete products associated with categories.

## Contributing

Contributions are welcome! Please feel free to submit a pull request.

1. Fork the repository.
2. Create your feature branch:
   ```bash
   git checkout -b feature/NewFeature
   ```
3. Commit your changes:
   ```bash
   git commit -m 'Add some feature'
   ```
4. Push to the branch:
   ```bash
   git push origin feature/NewFeature
   ```
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
