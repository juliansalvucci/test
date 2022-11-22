import styles from "./NavPage.module.css"

export const NavPage = ({ page, setPage }) => {
  let paginas = [0, 1, 2, 3, 4, 5, 6, 7];

  return (
    <div>
      <nav>
        <ul className="pagination">
          <li>
            <button className={styles.directioner} onClick={() => setPage(page - 1)}>
            <strong><h6>Anterior</h6></strong> 
            </button>
          </li>
          
          {paginas.map((p) => (
            <li  key={p}>
              <button className={styles.page} onClick={() => setPage(p)}>
                <strong><h4>{p + 1}</h4></strong> 
              </button>
            </li>
          ))}

          <li>
            <button className={styles.directioner} onClick={() => setPage(page + 1)}>
            <strong><h6>Siguiente</h6></strong> 
            </button>
          </li>
        </ul>
      </nav>
    </div>
  );
};
