import {Match} from "../models/Match.ts";
import {useEffect, useState} from "react";
import {getPopularMatches} from "../services/matchService.ts";
import Navbar from "./Navbar.tsx";
import * as React from "react";
import {MatchStatus} from "../models/MatchStatus.ts";

interface PopularMatches {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    setUser: React.Dispatch<React.SetStateAction<number>>;
    featureEnabled: boolean;
}

const PopularMatches: React.FC<PopularMatches> = ({ loggedIn, setLoggedIn, setUser, featureEnabled }) => {
    const [matches, setMatches] = useState<Match[]>([]);

    useEffect(() => {
        getPopularMatches(20).then((response => {
            setMatches(response);
        })).catch((error) => {
            console.error("Error fetching popular matches:", error);
        });
    }, []);
    return (
        <div className="container">
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser} popularEnabled={featureEnabled}/>
            <div className="dashboard-container">
                {
                    !featureEnabled ? (
                        <p>The "Popular Matches" feature is not enabled.</p>
                    ) : (
                        <table className="match-table">
                            <thead>
                            <tr>
                                <th>Home Team</th>
                                <th>Away Team</th>
                                <th>Match Date</th>
                                <th>Status</th>
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
                                </tr>
                            ))}
                            </tbody>
                        </table>
                    )
                }
            </div>
        </div>
    );
};
export default PopularMatches;