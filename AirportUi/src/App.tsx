// App.tsx
import { useState, useEffect } from 'react';
import Table from './components/Table/Table';
import FlightAnimation from './components/Animation/FlightAnimation';
import { Log } from './types/Log';

const baseAddress = 'http://localhost:5002';

function App() {
  const [logs, setLogs] = useState<Log[]>([]);
  const [lastLogId, setLastLogId] = useState<number>(0);

  useEffect(() => {
    const fetchInitialLogs = async () => {
      try {
        const response = await fetch(`${baseAddress}/api/Flights`);
        const data: Log[] = await response.json();
        setLogs(data);
        if (data.length > 0) {
          setLastLogId(data[data.length - 1].logId);
        }
      } catch (error) {
        console.error('Error fetching initial logs:', error);
      }
    };

    fetchInitialLogs();

    const fetchNewLogs = async () => {
      try {
        const response = await fetch(`${baseAddress}/api/Flights?startingId=${lastLogId}`);
        const data: Log[] = await response.json();
        if (data.length > 0) {
          setLogs(prevLogs => [...data, ...prevLogs]);
          setLastLogId(data[data.length - 1].logId);
        }
      } catch (error) {
        console.error('Error fetching new logs:', error);
      }
    };

    const interval = setInterval(fetchNewLogs, 1000);

    return () => clearInterval(interval);
  }, []);

  return (
    <div className="App">
      <FlightAnimation logs={logs} />
      <Table logs={logs} />
    </div>
  );
}

export default App;