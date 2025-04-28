import * as React from "react";
import Navbar from "./Navbar.tsx";
import {Match} from "../models/Match.ts";
import {ReturnedBet} from "../models/ReturnedBet.ts";
import {useEffect, useState} from "react";
import {getUserBets} from "../services/betService.ts";

interface YourBetsProps {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    setUser: React.Dispatch<React.SetStateAction<number>>;
    matches: Match[];
    user: number;
}

const YourBets: React.FC<YourBetsProps> = ({ loggedIn, setLoggedIn, setUser, matches, user }) => {
    const [bets, setBets] = useState<ReturnedBet[]>([]);
    
    const getTeamName = (type: string, bet: ReturnedBet) => {
        const match = matches.find((match) => match.id === bet.matchId);
        if (type === "home") {
            return match!.homeTeam;
        } else if (type === "away") {
            return match!.awayTeam;
        } else {
            return "";
        }
    }
    
    const getOutcomeString = (outcome: number) => {
        switch (outcome) {
            case 0:
                return "Home Win";
            case 1:
                return "Draw";
            case 2:
                return "Away Win";
            default:
                return "";
        }
    }

    useEffect(() => {
        const fetchBets = async () => {
            try{
                const data = await getUserBets(user);
                setBets(data);
            }catch (error){
                console.error("Error fetching matches:", error);
            }
        }


        fetchBets();
    }, []);
    return (
        <div className="container">
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser}/>
            <div className="dashboard-container">
                <h1>Your Bets</h1>
                <table className="match-table">
                    <thead>
                        <tr>
                            <th>Match</th>
                            <th>Bet Amount</th>
                            <th>Predicted Outcome</th>
                        </tr>
                    </thead>
                    <tbody>
                        {bets.map((bet) => (
                            <tr key={bet.id}>
                                <td>{`${getTeamName("home", bet)} vs ${getTeamName("away", bet)}`}</td>
                                <td>{bet.amount}</td>
                                <td>{getOutcomeString(bet.predictedOutcome)}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}; 
export default YourBets;