using ContratoTestWebApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace ContratoTestWebApi.Data
{
    public class UnidadComercialRepository
    {
        public string _cnnStr = "Server=localhost\\SQLEXPRESS;Database=TestBd;Trusted_Connection=True;";
        public List<UnidadComercial> GetAllUnidadesComerciales()
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM UnidadComercial";
            var list = cnn.Query<UnidadComercial>(query).ToList();
            return list;
        }
    }
}
