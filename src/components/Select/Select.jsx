import styles from './Select.module.css';

export const Select = ({setSort}) => {
  return (
    <div>
      <select onClick={e => {setSort(e.target.value)}}>
        <option value="ASC">Ascendente</option>
        <option value="DESC">Descendente</option>
      </select>
    </div>
  )
}
