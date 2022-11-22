export const Contrato = ({ contrato }) => {
  return (
    <>
      <tbody>
        <tr >
          <td>{contrato.cuit}</td>
          <td>{contrato.razonSocial}</td>
          <td>{contrato.trabajadores}</td>
          <td>{contrato.prima}</td>
          <td>{contrato.deuda}</td>
          <td>{contrato.siniestros}</td>
          <td>{contrato.inicioVigencia}</td>
          <td>{contrato.estado}</td>
          <td>{contrato.regimen}</td>
        </tr>
      </tbody>
    </>
  );
};
