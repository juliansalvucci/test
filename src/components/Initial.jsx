import { useState, useEffect } from "react";
import { Button } from "./Button/Button";
import {ContratoTable} from "./ContratoTable";
import { Select } from "./Select/Select";
import { SelectCant } from "./SelectCant/SelectCant";
import { NavPage } from "./NavPage/NavPage";
import { CantidadContratos } from "./CantidadContratos";
import { SearchInput } from "./SearchInput";

export const Initial = () => {
  const [contratos, setContratos] = useState([]);
  const [page, setPage] = useState(0); //Manejdador de estado para paginación.
  const [cantidad, setCantidad]  = useState(5);
  const [sort, setSort] = useState('ASC');
  const [loading, setLoading] = useState(true);

  

  useEffect(() => {
    async function fetchData() {
      const data = await fetch(`https://localhost:7128/api/GetAllContratos?cant=${cantidad}&pagina=${page}&sort=${sort}`);
      const results = await data.json();
      setContratos(results);
      setLoading(false)
    }
    fetchData();
  }, [page,sort,cantidad]);

  
  return (
    <div>
      {loading ? (
        <div>Loading...</div>
      ) : (
        <div>
          <SearchInput />
          <Button />
          <NavPage page={page} setPage={setPage} />
          <br />
          <div className="d-flex justify-content-between align-items-center">
            <Select setSort={setSort} />
            <SelectCant setCantidad={setCantidad} />
          </div>
          <ContratoTable contratos={contratos} />
          <CantidadContratos />
        </div>
      )}
    </div>
  );
};


