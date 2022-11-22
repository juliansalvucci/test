import React from 'react'
import { useState, useEffect } from "react";

export const CantidadContratosVigentes = () => {

    const [cantidadContratosVigentes, setCantidadContratosVigentes] = useState(0);

    useEffect(() => {
      async function getCantidadPaginas() {
        const data = await fetch(
          `https://localhost:7128/api/GetCantidadContratosVigentes`
        );
        const results = await data.json();
        setCantidadContratosVigentes(results);
        console.log(results);
      }
      getCantidadPaginas();
    }, []);

    return <div>Vigentes: {cantidadContratosVigentes}</div>;
}