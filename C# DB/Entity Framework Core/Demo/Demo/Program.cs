using Microsoft.Data.SqlClient;

string connectionString = "Server=.;Database=SoftUni;IntegratedSecurity=true;TrustServerCertificate=true;";
SqlConnection connection = new SqlConnection(connectionString); 
