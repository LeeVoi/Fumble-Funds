import {MatchStatus} from "./MatchStatus.ts";

export interface Match {
    id: number;
    homeTeam: string;
    awayTeam: string;
    startTime: Date;
    homeScore: number;
    awayScore: number;
    status: MatchStatus;
    bets: string[];
}