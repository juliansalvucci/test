import {Contrato} from "./Contrato";
import styles from "./Table.module.css"

export const ContratoTable = (props) => {
    return (
      <div>
        <table className="table">
          <thead>
            <tr>
              <th scope="col">Cuit</th>
              <th scope="col">RazonSocial</th>
              <th scope="col">Trabajadores</th>
              <th scope="col">Prima</th>
              <th scope="col">Deuda</th>
              <th scope="col">Siniestros</th>
              <th scope="col">InicioVigencia</th>
              <th scope="col">Estado</th>
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
  
