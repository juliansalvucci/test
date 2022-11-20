import {Contrato} from "./Contrato";

export const ContratoTable = (props) => {
    return (
      <div>
        <table className="table">
          <thead>
            <tr>
              <th scope="col">PolizaDigital</th>
              <th scope="col">Cuit</th>
              <th scope="col">RazonSocial</th>
              <th scope="col">Trabajadores</th>
              <th scope="col">Prima</th>
              <th scope="col">Deuda</th>
              <th scope="col">Siniestros</th>
              <th scope="col">InicioVigencia</th>
              <th scope="col">FinVigencia</th>
              <th scope="col">IdUnidadComercial</th>
              <th scope="col">AlicuotaFija</th>
              <th scope="col">AlicuotaVariable</th>
              <th scope="col">AlicuotasVigentes</th>
              <th scope="col">Estado</th>
              <th scope="col">CnoPedido</th>
              <th scope="col">CIIU</th>
              <th scope="col">NivelRiesgo</th>
              <th scope="col">Comision</th>
              <th scope="col">Regimen</th>
            </tr>
          </thead>
          {props.contratos.map((contrato) => (
            <Contrato key={contrato.id} contrato={contrato} />
          ))}
        </table>
      </div>
    );
};
  
export default ContratoTable;