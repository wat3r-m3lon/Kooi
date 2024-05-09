# Use the official mssql server 2022 image as the base image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables to accept the EULA and set a strong password for the SA account
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=KooeeAnu233

# Expose port 1003 for SQL Server
EXPOSE 1003

# Run SQL Server as the main process
CMD ["/opt/mssql/bin/sqlservr"]