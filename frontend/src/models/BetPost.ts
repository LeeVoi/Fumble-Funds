import {MatchOutcome} from "./MatchOutcome.ts";

export interface BetPost {
    userId: number;
    matchId: number;
    amount: number;
    predictedOutcome: MatchOutcome;
}