namespace ContratoTestWebApi.Models.Resquest
{
    public class BusquedaRequest
    {
        public int idUnidadComercial { get; set; }
        public int cantidad { get; set; }
        public int page { get; set; }
        public String sort { get; set; } = "";
        public String busqueda { get; set; } = "";
    }
}
