import { useEffect } from "react";

import React from 'react'

export const GetContratos = ({page,sort,cantidad,setContratos,setLoading}) => {
    async function fetchData() {
        const data = await fetch(
          `https://localhost:7128/api/GetAllContratos?cant=${cantidad}&pagina=${page}&sort=${sort}`
        );
        const results = await data.json();
        setContratos(results);
        setLoading(false);
      }
      
      useEffect(() => {
        fetchData();
      }, [page, sort, cantidad]);
}



