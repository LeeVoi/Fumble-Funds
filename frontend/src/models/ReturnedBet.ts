import {MatchOutcome} from "./MatchOutcome.ts";

export interface ReturnedBet {
    id: number;
    userId: number;
    matchId: number;
    amount: number;
    predictedOutcome: MatchOutcome;
    placedAt: Date;
}