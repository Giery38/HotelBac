dotnet ef migrations remove -s Hotel.API -p Hotel.Data -c HotelDbContext
dotnet ef migrations add initial -s Hotel.API -p Hotel.Data -c HotelDbContext -o Migrations/Postgres
Read-Host -Prompt "Press Enter to exit"