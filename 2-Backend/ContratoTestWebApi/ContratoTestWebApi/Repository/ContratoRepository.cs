using ContratoTestWebApi.Models;
using ContratoTestWebApi.Models.Resquest;
using Dapper;
using System.Data.SqlClient;

namespace ContratoTestWebApi.Data
{
    public class ContratoRepository
    {
        public string _cnnStr = "Server=localhost\\SQLEXPRESS;Database=TestBd;Trusted_Connection=True;";
        public  List<Contrato> GetAllContratos(BusquedaRequest br)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM Contrato
                ORDER BY Id {br.sort}                               
                OFFSET {br.cantidad * br.page} ROWS                               
                FETCH NEXT {br.cantidad} ROWS ONLY";
            var list = cnn.Query<Contrato>(query).ToList();
            return list;
        }

        public List<Contrato> GetContratosPorRazonSocial(BusquedaRequest br)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();

            var sort = br.sort;
            var cant = br.cantidad;
            var pagina = br.page;
            var razonSocial = br.busqueda;

            var query = @$"SELECT * FROM Contrato  
                WHERE RazonSocial LIKE @value
                ORDER BY Id {sort}                               
                OFFSET {cant * pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
            var list = cnn.Query<Contrato>(query, new { value = "%" + razonSocial + "%" }).ToList();
            return list;
        }

        public List<Contrato> GetContratosPorCuit(BusquedaRequest br)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();

            var sort = br.sort;
            var cant = br.cantidad;
            var pagina = br.page;
            var cuit = br.busqueda;

            var query = @$"SELECT * FROM Contrato  
                WHERE Cuit = {cuit}
                ORDER BY Id {sort}                               
                OFFSET {cant * pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
            var list = cnn.Query<Contrato>(query).ToList();
            return list;
        }
        public List<Contrato> GetContratosPorUnidadComercial(BusquedaRequest br)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM Contrato 
                WHERE IdUnidadComercial = {br.idUnidadComercial}
                ORDER BY Id {br.sort}                               
                OFFSET {br.cantidad * br.page} ROWS                               
                FETCH NEXT {br.cantidad} ROWS ONLY";
            var list = cnn.Query<Contrato>(query).ToList();
            return list;
        }

        public int GetCantidadPaginas()
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT COUNT(*) FROM Contrato";
            var list = cnn.Query<int>(query).First();
            return list;
        }

        public int GetCantidadContratosVigentes()
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT COUNT(*) FROM Contrato WHERE FinVigencia > GETDATE()";
            var list = cnn.Query<int>(query).First();
            return list;
        }

        public int GetCantidadContratosVigentesConDeuda()
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT COUNT(*) FROM Contrato WHERE FinVigencia > GETDATE() AND Deuda > 0";
            var list = cnn.Query<int>(query).First();
            return list;
        }
    }
}
