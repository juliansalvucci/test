import React from 'react'
import { useEffect } from 'react';

export const SelectUnidadComercial = ({unidadesComerciales,setUnidadesComerciales}) => {
  async function getUnidadesComerciales() {
    const data = await fetch(
      `https://localhost:7128/api/GetAllUnidadesComerciales`
    );
    const results = await data.json();
    setUnidadesComerciales(results)
    console.log(unidadesComerciales)
  }

  useEffect(() => {
    getUnidadesComerciales();
  }, []);

  return (
    <div>
      <select>
        {unidadesComerciales.map((uc) => {
          <option>{uc.nombreUnidadComercial}</option>
        })}
      </select>
    </div>
  );
}
