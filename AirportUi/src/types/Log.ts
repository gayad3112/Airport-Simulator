export interface Log {
    logId: number;
    flightNumber: string;
    flightStatus: number;
    leg: number | null;
    in: string | null;
    out: string | null;
  }