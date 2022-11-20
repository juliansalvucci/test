import { useState, useEffect } from "react";
import {ContratoTable} from "./Contrato/ContratoTable";
import { Select } from "./Select/Select";
import { SelectCant } from "./SelectCant/SelectCant";
import { NavPage } from "./NavPage/NavPage";
import { CantidadContratos } from "./CantidadContratos/CantidadContratos";
import { SearchInput } from "./SearchInput/SearchInput";
import { SelectUnidadComercial } from "./SelectUnidadComercial/SelectUnidadComercial";

export const Initial = () => {
  const [contratos, setContratos] = useState([]);
  const [unidadesComerciales, setUnidadesComerciales] = useState([]);
  const [page, setPage] = useState(0); //Manejdador de estado para paginación.
  const [cantidad, setCantidad]  = useState(5);
  const [sort, setSort] = useState('ASC');
  const [loading, setLoading] = useState(true);
  const [busqueda, setBusqueda] = useState("");

  async function fetchData() {
    if (busqueda === "" && page >= 0) {
      const data = await fetch(
        `https://localhost:7128/api/GetAllContratos?cant=${cantidad}&pagina=${page}&sort=${sort}`
      );
      const results = await data.json();
      setContratos(results);
      setLoading(false);
    }
  }

  useEffect(() => {
    fetchData();
  }, [page,sort,cantidad,busqueda]);

  
  return (
    <div>
      {loading ? (
        <div className="spinner-border text-danger" role="status"></div>
      ) : (
        <div>
          <SearchInput setContratos={setContratos} cantidad={cantidad} page={page} sort={sort} busqueda={busqueda} setBusqueda={setBusqueda} />
          <div className="container">
            <NavPage page={page} setPage={setPage} />
          </div>

          <br />
          <div className="d-flex justify-content-between align-items-center">
            <Select setSort={setSort} />
            <SelectCant setCantidad={setCantidad} />
          </div>
          <ContratoTable contratos={contratos} />
          <CantidadContratos />
          <SelectUnidadComercial unidadesComerciales={unidadesComerciales} setUnidadesComerciales={setUnidadesComerciales}/>
        </div>
      )}
    </div>
  );
};


