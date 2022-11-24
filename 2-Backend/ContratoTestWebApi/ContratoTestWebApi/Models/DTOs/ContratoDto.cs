namespace ContratoTestWebApi.Models.DTOs
{
    public class ContratoDto
    {
  
        public int NumeroContrato { get; set; }
        public String Cuit { get; set; } = "";
        public String RazonSocial { get; set; } = "";
        public int Trabajadores { get; set; }
        public decimal Prima { get; set; }
        public decimal Deuda { get; set; }
        public int Siniestros { get; set; }
        public DateTime InicioVigencia { get; set; }
        public String Estado { get; set; } = "";
        public String Regimen { get; set; } = "";
    }
}
