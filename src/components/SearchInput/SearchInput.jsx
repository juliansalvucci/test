import { useEffect, useState } from "react";
import styles from "./Button.module.css";
import InputStyles from "./input.module.css";

export const SearchInput = ({
  setContratos,
  page,
  sort,
  cantidad,
  busqueda,
  setBusqueda,
}) => {
  const [criterioBusqueda, setCriterioBusqueda] = useState();

  async function buscar() {
    await buscarPorCuit();
    await searchRazonSocial();
  }

  async function buscarPorCuit() {
    try {
      if (busqueda !== "" && page >= 0 && criterioBusqueda === "CUIT") {
        const data = await fetch(
          `https://localhost:7128/api/GetContratosPorCuit?cant=${cantidad}&pagina=${page}&sort=${sort}&cuit=${busqueda}`
        );
        const results = await data.json();
        setContratos(results);
      }
    } catch (e) {
      console.log(e);
    }
  }

  async function searchRazonSocial() {
    try {
      if (busqueda !== "" && page >= 0 && criterioBusqueda === "RAZONSOCIAL") {
        const data = await fetch(
          `https://localhost:7128/api/GetContratosPorRazonSocial?cant=${cantidad}&pagina=${page}&sort=${sort}&razonSocial=${busqueda}`
        );
        const results = await data.json();
        setContratos(results);
      }
    } catch (e) {
      console.log(e);
    }
  }

  useEffect(() => {
    buscarPorCuit();
    searchRazonSocial();
  }, [page, sort, cantidad]);

  return (
    <div className="d-flex">
      <div className="col-md-4">
        <h6>Criterio de búsqueda:</h6>
        <select
          onClick={(e) => {
            setCriterioBusqueda(e.target.value);
          }}
        >
          <option value="CUIT">Cuit</option>
          <option value="RAZONSOCIAL">Razón social</option>
        </select>
      </div>
      <div className="col-md-4">
        <input
          type="text"
          className={InputStyles.inputContainer}
          onChange={(e) => setBusqueda(e.target.value)}
        />
        <button onClick={buscar} className={styles.button}>
          Buscar
        </button>
      </div>
    </div>
  );
};
