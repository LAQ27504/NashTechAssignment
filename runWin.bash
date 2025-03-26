#!/bin/bash

# Navigate to the project directory
cd "$(dirname "$0")/assignment"

# Build the project
dotnet build

# Run the project
dotnet run