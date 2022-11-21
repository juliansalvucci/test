import { useState, useEffect } from "react";
import { ContratoTable } from "./Contrato/ContratoTable";
import { Select } from "./Select/Select";
import { SelectCant } from "./SelectCant/SelectCant";
import { NavPage } from "./NavPage/NavPage";
import { CantidadContratos } from "./CantidadContratos/CantidadContratos";
import { SearchInput } from "./SearchInput/SearchInput";
import { SelectUnidadComercial } from "./SelectUnidadComercial/SelectUnidadComercial";

export const Initial = () => {
  const [contratos, setContratos] = useState([]);
  const [idUnidadComercial, setIdUnidadComercial] = useState(0);
  const [page, setPage] = useState(0); //Manejdador de estado para paginación.
  const [cantidad, setCantidad] = useState(5);
  const [sort, setSort] = useState("ASC");
  const [loading, setLoading] = useState(true);
  const [busqueda, setBusqueda] = useState("");

  async function fetchData() {
    if (busqueda === "" && page >= 0 && idUnidadComercial == 0) {
      const data = await fetch(
        `https://localhost:7128/api/GetAllContratos?cant=${cantidad}&pagina=${page}&sort=${sort}`
      );
      const results = await data.json();
      setContratos(results);
      setLoading(false);
    }
  }

  async function fetchData2() {
    if (busqueda === "" && page >= 0 && idUnidadComercial !== 0) {
      const data = await fetch(
        `https://localhost:7128/api/GetContratosPorUnidadComercial?cant=${cantidad}&pagina=${page}&sort=${sort}&idUnidadComercial=${idUnidadComercial}`
      );
      const results = await data.json();
      setContratos(results);
      setLoading(false);
    }
  }

  useEffect(() => {
    fetchData();
    fetchData2();
  }, [page, sort, cantidad, busqueda, idUnidadComercial]);

  return (
    <div>
      {loading ? (
        <div className="spinner-border text-danger" role="status"></div>
      ) : (
        <div className="container">
          <br />
          <div className="card">
          <br />
            <SearchInput
              setContratos={setContratos}
              cantidad={cantidad}
              page={page}
              sort={sort}
              busqueda={busqueda}
              setBusqueda={setBusqueda}
            />

            <br />
            <div className="d-flex">
              <div className="justify-content-start col-md-4">
                <Select setSort={setSort} />
              </div>
              <div className="justify-content-end col-md-12">
                <SelectCant setCantidad={setCantidad} />
              </div>
            </div>

            <SelectUnidadComercial
              idUnidadComercial={idUnidadComercial}
              setIdUnidadComercial={setIdUnidadComercial}
            />
            <br />
            <div className="container">
              <ContratoTable contratos={contratos} />
            </div>

            <CantidadContratos />
            <br />
            <div className="d-flex justify-content-center">
              <NavPage page={page} setPage={setPage} />
            </div>
          </div>
        </div>
      )}
    </div>
  );
};
