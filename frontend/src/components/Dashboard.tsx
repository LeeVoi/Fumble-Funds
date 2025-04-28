import {useEffect, useState} from "react";
import {Match} from "../models/Match.ts";
import {MatchStatus} from "../models/MatchStatus.ts";
import {getMatches} from "../services/matchService.ts";

interface DashboardProps{
    userId: number;
}


const Dashboard: React.FC<DashboardProps> = ({userId}: DashboardProps) => {
    const [matches, setMatches] = useState<Match[]>([]);
    
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
                            <button className="bet-button">Bet</button>
                        </td>}
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
export default Dashboard;