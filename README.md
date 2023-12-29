# Galytix Web API Project

This project is a self-hosted web API server developed in C# using .NET Core and Kestrel. It serves as a platform for processing data from the 'gwpByCountry.csv' file located in the 'Data' folder. The primary purpose is to calculate and provide average Gross Written Premium (GWP) values for specific countries and lines of business.

## Introduction

This project is a web API that reads data from a CSV file containing information about Gross Written Premiums (GWP) by country, variable, and line of business. The API provides functionality to calculate average GWP values for specific countries and lines of business based on user-defined criteria.

## Features

- Self-hosted web API using .NET Core and Kestrel.
- Utilizes the CsvHelper library for reading data from the 'gwpByCountry.csv' file.
- Implements an endpoint (`/api/gwp/avg`) for calculating average GWP values based on user-defined criteria.
- Supports asynchronous operations for improved performance.

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository:
2. Open the project in Visual Studio or your preferred IDE.
3. Build and run the project.
4. Access the API at http://localhost:9091.

## Dependencies
- .NET Core 3.0 or later
- CsvHelper library (version 30.0.1)
