
export const Select = ({setSort}) => {
  return (
    <div >
      <h6>Ordenamiento: </h6>
      <select onClick={e => {setSort(e.target.value)}}>
        <option value="ASC">Ascendente</option>
        <option value="DESC">Descendente</option>
      </select>
    </div>
  )
}
