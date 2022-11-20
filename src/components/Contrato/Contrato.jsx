export const Contrato = ({ contrato }) => {
  return (
    <>
      <tbody>
        <tr >
          <td>{contrato.polizaDigital}</td>
          <td>{contrato.cuit}</td>
          <td>{contrato.razonSocial}</td>
          <td>{contrato.trabajadores}</td>
          <td>{contrato.prima}</td>
          <td>{contrato.deuda}</td>
          <td>{contrato.siniestros}</td>
          <td>{contrato.inicioVigencia}</td>
          <td>{contrato.finVigencia}</td>
          <td>{contrato.idUnidadComercial}</td>
          <td>{contrato.alicuotaFija}</td>
          <td>{contrato.alicuotaVariable}</td>
          <td>{contrato.alicuotasVigentes}</td>
          <td>{contrato.estado}</td>
          <td>{contrato.cnoPedido}</td>
          <td>{contrato.ciiu}</td>
          <td>{contrato.nivelRiesgo}</td>
          <td>{contrato.comision}</td>
          <td>{contrato.regimen}</td>
        </tr>
      </tbody>
    </>
  );
};