import React from "react";
import { useState, useEffect } from "react";

export const SearchInput = ({ setContratos,page,sort,cantidad, busqueda ,setBusqueda }) => {

  async function search() {
    if (busqueda !== "" && page >= 0) {
      const data = await fetch(
        `https://localhost:7128/api/GetContratosPorCuit?cant=${cantidad}&pagina=${page}&sort=${sort}&cuit=${busqueda}`
      );
      const results = await data.json();
      setContratos(results);
    }
  }

  useEffect(() => {
    search();
  }, [page,sort,cantidad]);

  return (
    <div>
      {busqueda}
      <input type="text" onChange={(e) => setBusqueda(e.target.value)} />
      <button onClick={search}>Buscar</button>
    </div>
  );
};
