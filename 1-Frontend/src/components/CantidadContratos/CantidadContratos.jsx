import React from 'react'
import { useState, useEffect } from "react";

export const CantidadContratos = () => {

    const [cantidadContratos, setCantidadContratos] = useState(0);

    useEffect(() => {
      async function getCantidadPaginas() {
        const data = await fetch(
          `https://localhost:7128/api/GetCantidadPaginas`
        );
        const results = await data.json();
        setCantidadContratos(results);
        console.log(results);
      }
      getCantidadPaginas();
    }, []);

    return <div>Todos: {cantidadContratos}</div>;
}
