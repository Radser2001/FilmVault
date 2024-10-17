# FilmVault 🎬
FilmVault is a .NET API for managing a movie catalog. It provides functionalities for adding, retrieving, updating, and deleting movies, along with managing directors and genres. This project demonstrates skills in API development using ASP.NET Core and Entity Framework Core.

## Purpose
The primary goal of this project is to enhance my skills in .NET development, particularly in building RESTful APIs. By working on FilmVault, I aim to gain practical experience with ASP.NET Core, Entity Framework Core, and database management.

## Features
- **Movies**: Add, retrieve, update, and delete movies.
- **Directors**: Manage movie directors, including their award-winning status (CRUD operations planned for future implementation).
- **Genres**:  Categorize movies with multiple genres (CRUD operations planned for future implementation).
- **Database**: Uses SQLite for persistent data storage.
- **API Endpoints**: RESTful API design for seamless client interaction.

## Technologies Used
- **ASP.NET Core**: For building the web API.
- **Entity Framework Core**: ORM for database interactions.
- **SQLite**: Lightweight database for persistent data storage.
- **Swagger**: API documentation and testing interface.
- **Dependency Injection**: For service management and scalability.

## Setup and Installation

1. **Clone the repository**:

    ```bash
    git clone https://github.com/Radser2001/FilmVault
    cd FilmVault
    ```

2. **Install dependencies**:

    ```bash
    dotnet restore
    ```

3. **Configure the database connection** in `appsettings.json`:

    ```json
    "ConnectionStrings": {
    "FilmVaultDb": "Data Source=FilmVault.db"
    }
    ```

4. **Apply database migrations**:

    ```bash
    dotnet ef database update
    ```


## Running the Application

1. Run the API locally:

    ```bash
    dotnet run
    ```

2. Access the API via:
    - `http://localhost:5041`
    - `https://localhost:5041` (for HTTPS)


## API Endpoints
- `GET /movie`: Get all movies
- `GET /movie/{id}`:  Get a movie by ID
- `POST /movie`: Add a new movie
  - Example JSON request:

    ```json
    {
        "title": "Inception",
        "directorId": 1,
        "genres": [1, 2],
        "isAvailableIn4K": true
    }
    ```

- `PUT /movie/{id}`: Update an existing movie
- `DELETE /movie/{id}`: Delete a movie


## Future Enhancements
- Add Genre Management.
- Add Director Management.
- Add user authentication and authorization.
- Implement search and filtering for movies.
- Add more advanced features like movie reviews and ratings.
