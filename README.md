# AniWiki Backend

The backend of the AniWiki project is designed to fetch and process data from the [Jikan API](https://docs.api.jikan.moe/). The backend handles requests from the frontend, providing users with detailed anime information based on the anime ID and supporting pagination for list outputs.

## Features

- **Fetch Anime Data**: Sends requests to the Jikan API to retrieve anime data based on the user's input on the frontend.
- **Detailed Anime Information**: Provides detailed information about each anime by its unique ID.
- **Pagination Support**: Implements pagination for retrieving anime lists, ensuring efficient data retrieval for large lists.

## Architecture

The project is built using ASP.NET Core Web API with the following structure:

- **Controllers**: Handle incoming HTTP GET requests.
- **Services**: Contain the logic for fetching and processing data from the Jikan API.

## Installation

1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```

2. Navigate to the project directory:
    ```bash
    cd aniwiki-backend
    ```

3. Make sure you have .NET 8.0 installed.

4. Run the application:
    ```bash
    dotnet run
    ```

The application will now be running and ready to handle requests.

## API Endpoints

### 1. Get Anime by ID

- **GET** `/api/anime/{id}`
- **Description**: Retrieves detailed information about an anime based on its ID.

### 2. Get Anime List with Pagination

- **GET** `/api/anime?page={pageNumber}`
- **Description**: Retrieves a paginated list of anime.

## Technologies Used

- **ASP.NET Core Web API**: For building the backend services.
- **Jikan API**: For fetching anime data.
- **C#**: For the backend logic and services.
