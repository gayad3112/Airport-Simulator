interface TableRowProps {
  logNumber: number;
  flightStatus: string;
  flightNumber: string;
  leg: string;
  timeIn: string;
  timeOut: string;
}

const TableRow = ({ logNumber, flightStatus, flightNumber, leg, timeIn, timeOut }: TableRowProps) => (
  <tr>
    <td>{logNumber}</td>
    <td>{flightStatus}</td>
    <td>{flightNumber}</td>
    <td>{leg}</td>
    <td>{timeIn}</td>
    <td>{timeOut}</td>
  </tr>
);

export default TableRow;
