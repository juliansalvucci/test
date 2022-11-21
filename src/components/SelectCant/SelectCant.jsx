
export const SelectCant = ({setCantidad}) => {
  return (
    <div>
      <h6>Registros por página </h6>
      <select onClick={e => {setCantidad(e.target.value)}}>
        <option value="5">5</option>
        <option value="10">10</option>
        <option value="15">15</option>
      </select>
    </div>
  )
}