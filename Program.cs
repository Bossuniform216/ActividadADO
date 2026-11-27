using Microsoft.Data.Sqlite;

string connectionString =
    "Data Source=videojuegos.db";

using (var conexion =
    new SqliteConnection(connectionString))
{
    conexion.Open();

    string crearTabla = @"
    CREATE TABLE IF NOT EXISTS Videojuegos
    (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Nombre TEXT,
        Genero TEXT
    );
    ";

    using var comandoCrear =
        new SqliteCommand(crearTabla, conexion);

    comandoCrear.ExecuteNonQuery();

    string insertar1 =
        "INSERT INTO Videojuegos (Nombre, Genero) VALUES ('Elden Ring','RPG');";

    string insertar2 =
        "INSERT INTO Videojuegos (Nombre, Genero) VALUES ('Minecraft','Sandbox');";

    string insertar3 =
        "INSERT INTO Videojuegos (Nombre, Genero) VALUES ('GTA V','Accion');";

    new SqliteCommand(insertar1, conexion)
        .ExecuteNonQuery();

    new SqliteCommand(insertar2, conexion)
        .ExecuteNonQuery();

    new SqliteCommand(insertar3, conexion)
        .ExecuteNonQuery();

    string consulta =
        "SELECT * FROM Videojuegos";

    using var comandoConsulta =
        new SqliteCommand(consulta, conexion);

    using var reader =
        comandoConsulta.ExecuteReader();

    Console.WriteLine("LISTA DE VIDEOJUEGOS");

    while (reader.Read())
    {
        Console.WriteLine(
            $"{reader["Id"]} - {reader["Nombre"]} - {reader["Genero"]}");
    }
}