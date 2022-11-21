export const NavPage = ({ page, setPage }) => {
  let paginas = [0, 1, 2, 3, 4, 5, 6, 7];

  return (
    <div>
      <nav>
        <ul className="pagination">
          <li className="page-item">
            <button className="page-link" onClick={() => setPage(page - 1)}>
              Anterior
            </button>
          </li>
          {paginas.map((p) => (
            <li className="page-item" key={p}>
              <button className="page-link" onClick={() => setPage(p)}>
                {p + 1}
              </button>
            </li>
          ))}

          <li className="page-item">
            <button className="page-link" onClick={() => setPage(page + 1)}>
              Siguiente
            </button>
          </li>
        </ul>
      </nav>
    </div>
  );
};
