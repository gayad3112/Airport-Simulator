import { useState, useEffect } from 'react';
import { Log } from '../../types/Log';


interface FlightAnimationProps {
  logs: Log[];
}

const FlightAnimation = ({logs}: FlightAnimationProps ) => {
  const [flightPositions, setFlightPositions] = useState<Record<string, number>>({});

  useEffect(() => {
    const newPositions: Record<string, number> = {};
    logs.forEach(log => {
      if (log.leg !== null) {
        newPositions[log.flightNumber] = log.leg;
      } else {
        delete newPositions[log.flightNumber];
      }
    });
    setFlightPositions(newPositions);
  }, [logs]);

  const renderPlaneIcon = (flightNumber: string, leg: number) => {
    // Position calculation would depend on your specific layout
    const x = 100 + leg * 100; // Example positioning
    const y = 100;
    return (
      <g key={flightNumber} transform={`translate(${x}, ${y})`}>
        <rect width="40" height="20" fill="blue" />
        <text x="5" y="15" fill="white" fontSize="12">{flightNumber}</text>
      </g>
    );
  };

  return (
    <svg width="800" height="400" viewBox="0 0 800 400">
      {/* Draw the leg diagram */}
      <path d="M100,100 L700,100 M400,100 L400,300 M300,200 L500,200" stroke="black" fill="none" />
      <text x="750" y="100">1</text>
      <text x="650" y="100">2</text>
      <text x="550" y="100">3</text>
      <text x="450" y="100">4</text>
      <text x="350" y="200">5</text>
      <text x="450" y="200">8</text>
      <text x="350" y="300">6</text>
      <text x="450" y="300">7</text>

      {/* Render plane icons */}
      {Object.entries(flightPositions).map(([flightNumber, leg]) => 
        renderPlaneIcon(flightNumber, leg)
      )}
    </svg>
  );
};

export default FlightAnimation;