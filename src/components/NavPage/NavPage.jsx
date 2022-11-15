export const NavPage = ({page,setPage}) => {
    return (
      <header className="d-flex justify-content-between align-items-center">
        <button
          className="btn btn-primary btn-sm"
          onClick={() => setPage(page - 1)}
        >
          Atras
        </button>

        Página: {page}
  
        <button
          className="btn btn-primary btn-sm"
          onClick={() => setPage(page + 1)}
        >
          Siguiente
        </button>
      </header>
    );
  }