import {useEffect, useState} from "react";
import {Match} from "../models/Match.ts";
import {MatchStatus} from "../models/MatchStatus.ts";
import {getMatches} from "../services/matchService.ts";
import {useNavigate} from "react-router-dom";
import Navbar from "./Navbar.tsx";
import * as React from "react";

interface DashboardProps{
    userId: number;
    handleSetMatch: (match: Match) => void;
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    setUser: React.Dispatch<React.SetStateAction<number>>;
}


const Dashboard: React.FC<DashboardProps> = ({userId, handleSetMatch, loggedIn, setLoggedIn, setUser}: DashboardProps) => {
    const [matches, setMatches] = useState<Match[]>([]);
    const navigate = useNavigate();
    
    const handleClickBet = (match: Match) => {
        handleSetMatch(match);
        console.log(match);
        navigate("createbet");
    }
    
    useEffect(() => {
        const fetchMatches = async () => {
            try{
                const data = await getMatches();
                setMatches(data);
            }catch (error){
                console.error("Error fetching matches:", error);
            }
        }
        console.log("Fetching matches...");
        console.log(matches);
        
        fetchMatches();
    }, []);
    
    return (
        <div className="container">
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser}/>
            <div className="dashboard-container">
                <table className="match-table">
                    <thead>
                    <tr>
                        <th>Home Team</th>
                        <th>Away Team</th>
                        <th>Match Date</th>
                        <th>Status</th>
                        {userId !== -1 && <th>Place Bet</th>}
                    </tr>
                    </thead>
                    <tbody>
                    {matches.map((match) => (
                        <tr key={match.id}>
                            <td>
                                {match.homeTeam} ({match.homeScore !== null ? match.homeScore : "-"})
                            </td>
                            <td>
                                {match.awayTeam} ({match.awayScore !== null ? match.awayScore : "-"})
                            </td>
                            <td>{new Date(match.startTime).toLocaleDateString()}</td>
                            <td>{MatchStatus[match.status]}</td>
                            {userId !== -1 && <td>
                                <button className="bet-button" onClick={() => handleClickBet(match)}>Bet</button>
                            </td>}
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        </div>

    );
}
export default Dashboard;