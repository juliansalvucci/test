import { useEffect, useState } from "react";
import styles from "./Button.module.css";
import InputStyles from "./input.module.css";

export const SearchInput = ({
  setContratos,
  form,
  setBusqueda,
}) => {
  const [criterioBusqueda, setCriterioBusqueda] = useState('CUIT');

  async function buscar() {
    switch (criterioBusqueda) {
      case "CUIT":
        await buscarPorCuit();
        break;
      case "RAZONSOCIAL":
        await buscarPorRazonSocial();
        break;
    }
  }

  async function buscarPorCuit() {
    try {
      if (form.busqueda !== "" && form.page >= 0) {
        const data = await fetch(
          `https://localhost:7128/api/GetContratosPorCuit`,
          {
            method: "POST",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(form),
          }
        );
        const results = await data.json();
        setContratos(results);
      }
    } catch (e) {
      console.log(e);
    }
  }

  useEffect(()=>{
    buscar();
  },[form.page, form.cantidad, form.sort])

  async function buscarPorRazonSocial() {
    try {
      if (form.busqueda !== "" && form.page >= 0) {
        console.log("PESCA", form);
        const data = await fetch(
          `https://localhost:7128/api/GetContratosPorRazonSocial`,
          {
            method: "POST",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(form),
          }
        );
        const results = await data.json();
        console.log("resultados", results);
        setContratos(results);
      }
    } catch (e) {
      console.log(e);
    }
  }

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
