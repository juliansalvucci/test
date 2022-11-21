import React from 'react'
import { useEffect, useState } from 'react';

export const SelectUnidadComercial = ({
  idUnidadComercial,
  setIdUnidadComercial
}) => {

  const [unidadesComerciales, setUnidadesComerciales] = useState([]);

  async function getUnidadesComerciales() {
    const data = await fetch(
      `https://localhost:7128/api/GetAllUnidadesComerciales`
    );
    const results = await data.json();
    setUnidadesComerciales(results);
  }


  useEffect(() => {
    getUnidadesComerciales();
  }, []);

  return (
    <div>
      <h6>Unidad comercial: </h6>
      <select
      value={idUnidadComercial}
      onChange={(e)=>{
        const selected = e.target.value;
        setIdUnidadComercial(selected);
      }}>
        <option value={0}>TODOS</option>
        {unidadesComerciales.map((uc) => {
          return <option key={uc.id} value={uc.id}>{uc.nombreUnidadComercial}</option>;
        })}
      </select>
    </div>
  );
};
