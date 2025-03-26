@echo off

:: Navigate to the project directory
cd /d "%~dp0\assignment"
:: Build the project
dotnet build

:: Run the project
dotnet run