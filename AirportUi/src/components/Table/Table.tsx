
import { Log } from '../../types/Log';
import TableRow from '../TableRow/TableRow';
import './Table.css';

interface TableProps {
  logs: Log[];
}

const Table = ({ logs }: TableProps) => {

  return (
    <div className="table-container">
      <table>
        <thead>
          <tr>
            <th>Log Number</th>
            <th>Flight Status</th>
            <th>Flight Number</th>
            <th>Leg</th>
            <th>Time In</th>
            <th>Time Out</th>
          </tr>
        </thead>
        <tbody>
          {logs.map(log => (
            <TableRow
              key={log.logId}
              logNumber={log.logId}
              flightStatus={log.flightStatus === 0 ? 'Arrival' : 'Departure'}
              flightNumber={log.flightNumber}
              leg={log.leg ? log.leg.toString() : 'flight finished its course'}
              timeIn={log.in ? new Date(log.in).toLocaleString() : ''}
              timeOut={log.out ? new Date(log.out).toLocaleString() : ''}
            />
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Table;