import React from 'react'
import { useState, useEffect } from "react";

export const CantidadContratosVigentesConDeuda = () => {

    const [cantidadContratosVigentesConDeuda, setCantidadContratosVigentesConDeuda] = useState(0);

    useEffect(() => {
      async function getCantidadPaginas() {
        const data = await fetch(
          `https://localhost:7128/api/GetCantidadContratosVigentesConDeuda`
        );
        const results = await data.json();
        setCantidadContratosVigentesConDeuda(results);
        console.log(results);
      }
      getCantidadPaginas();
    }, []);

    return <div>Vigentes con deuda: {cantidadContratosVigentesConDeuda}</div>;
}