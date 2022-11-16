import React from 'react'

async function search() {
    const data = await fetch(
      `https://localhost:7128/api/GetContratosPorRazonSocial`
    );
    const results = await data.json();
    console.log(results);
}

export const SearchInput = () => {
  return (
    <div>
      <input type="text" />
      <button onClick={search} >Buscar</button>
    </div>
  );
};
