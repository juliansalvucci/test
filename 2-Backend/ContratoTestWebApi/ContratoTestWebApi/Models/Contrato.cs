using System;

namespace ContratoTestWebApi.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int PolizaDigital { get; set; }
        public int NumeroContrato { get; set; }
        public String Cuit { get; set; } = "";
        public String RazonSocial { get; set; } =  "";
        public int Trabajadores { get; set; }
        public decimal Prima { get; set; }
        public decimal Deuda { get; set; }
        public int Siniestros { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public int IdUnidadComercial { get; set; }
        public decimal AlicuotaFija { get; set; }
        public decimal AlicuotaVariable { get; set; }
        public String AlicuotasVigentes { get; set; } = "";
        public String Estado { get; set; } = "";
        public String CnoPedido { get; set; } = "";
        public String CIIU { get; set; } = "";
        public String NivelRiesgo { get; set; } = "";
        public String Comision { get; set; } = "";
        public String Regimen { get; set; } = "";
    }
}
