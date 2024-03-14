using Common.Data;
using DAL.MySql;
using DAL.SqlServer;

SqlServerFunctions sqlServer = new();
MySqlFunctions mySql = new();

Console.WriteLine("Filmes no banco SQLServer\n");

sqlServer.ListAll<Filme>();

Console.WriteLine("\n\nCategorias no banco SQLServer\n");

sqlServer.ListAll<Categoria>();

Console.WriteLine("\n\nFilmes no banco MySQL\n");

mySql.ListAll<Filme>();

Console.WriteLine("\n\nCategorias no banco MySQL\n");

mySql.ListAll<Categoria>();

//var filme = new Filme
//{
//    Titulo = "Um Sonho de Liberdade",
//    Ano = new DateTime(1995, 3, 17, 0, 0, 0, DateTimeKind.Utc)
//};

//mySql.Add(filme);
//mySql.Update(filme);
//mySql.Delete<Filme>(6);
//mySql.Find<Filme>(6);

Console.ReadKey();
