﻿using ContratoTestWebApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace ContratoTestWebApi.Data
{
    public class ContratoData
    {
        public string _cnnStr = "Server=localhost\\SQLEXPRESS;Database=TestBd;Trusted_Connection=True;";
        public  List<Contrato> GetAllContratos(int cant, int pagina, String sort)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM Contrato
                ORDER BY Id {sort}                               
                OFFSET {cant*pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
            var list = cnn.Query<Contrato>(query).ToList();
            return list;
        }

        public List<Contrato> GetContratosPorRazonSocial(int cant, int pagina, String sort, string razonSocial)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();

            var query = @$"SELECT * FROM Contrato  
                WHERE RazonSocial LIKE @value
                ORDER BY Id {sort}                               
                OFFSET {cant * pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
            var list = cnn.Query<Contrato>(query, new { value = "%" + razonSocial + "%" }).ToList();
            return list;
        }

        public List<Contrato> GetContratosPorCuit(int cant, int pagina, String sort, string cuit)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM Contrato  
                WHERE Cuit = {cuit}
                ORDER BY Id {sort}                               
                OFFSET {cant * pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
            var list = cnn.Query<Contrato>(query).ToList();
            return list;
        }
        public List<Contrato> GetContratosPorUnidadComercial(int cant, int pagina, string sort, int idUnidadComercial)
        {
            using var cnn = new SqlConnection(_cnnStr);
            cnn.Open();
            var query = @$"SELECT * FROM Contrato 
                WHERE IdUnidadComercial = {idUnidadComercial}
                ORDER BY Id {sort}                               
                OFFSET {cant * pagina} ROWS                               
                FETCH NEXT {cant} ROWS ONLY";
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
