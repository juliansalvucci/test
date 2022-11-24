import { useState, useEffect } from "react";
import { ContratoTable } from "./Contrato/ContratoTable";
import { Select } from "./Select/Select";
import { SelectCant } from "./SelectCant/SelectCant";
import { NavPage } from "./NavPage/NavPage";
import { CantidadContratos } from "./CantidadContratos/CantidadContratos";
import { CantidadContratosVigentes } from "./CantidadContratos/CantidadContratosVigentes";
import { CantidadContratosVigentesConDeuda } from "./CantidadContratos/CantidadContratosVigentesConDeuda";
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
  const [form, setForm] = useState({
    idUnidadComercial: 0,
    cantidad: 5,
    page: 0,
    sort: "",
    busqueda: "",
  });

  async function buscarTodosLosContratos() {
    if (busqueda === "" && page >= 0 && idUnidadComercial == "0") {
      const data = await fetch(`https://localhost:7128/api/GetAllContratos`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(form),
      });
      const results = await data.json();
      setContratos(results);
      setLoading(false);
    }
  }

  async function buscarContratosPorUnidadComercial() {
    if (busqueda === "" && page >= 0 && idUnidadComercial !== 0) {
      const data = await fetch(
        `https://localhost:7128/api/GetContratosPorUnidadComercial`,
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
      setLoading(false);
    }
  }

  useEffect(() => {
    let obj = {
      idUnidadComercial: idUnidadComercial,
      cantidad: cantidad,
      page: page,
      sort: sort,
      busqueda: busqueda,
    };

    console.log(form);

    setForm((form) => ({
      ...form, //se deben llamar igual.
      ...obj,
    }));

    console.log("EN SCOPE", form);
  }, [page, sort, cantidad, busqueda, idUnidadComercial]);

  useEffect(() => {
    buscarTodosLosContratos();
    buscarContratosPorUnidadComercial();
    console.log("FUERA SCOPE", form);
  }, [form]);

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
              setBusqueda={setBusqueda}
              form={form}
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
              setIdUnidadComercial={setIdUnidadComercial}
            />
            <hr />
            <div className="d-flex">
              <div className="justify-content-start col-md-4">
                <CantidadContratos />
              </div>
              <div className="justify-content-start col-md-4">
                <CantidadContratosVigentes />
              </div>
              <div className="justify-content-start col-md-4">
                <CantidadContratosVigentesConDeuda />
              </div>
            </div>
            <hr />
            <div className="container">
              <ContratoTable contratos={contratos} />
            </div>

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
