import { Routes, Route} from "react-router-dom";
import {useEffect, useState} from "react";
import "./App.css";
import Login from "./pages/Login.tsx";
import SignUp from "./pages/SignUp.tsx";
import Dashboard from "./components/Dashboard.tsx";
import CreateBet from "./components/CreateBet.tsx";
import * as React from "react";
import {Match} from "./models/Match.ts";
import {getMatches} from "./services/matchService.ts";
import YourBets from "./components/YourBets.tsx";

function App() {
    const [user, setUser] = useState<number>(-1);
    const [loggedIn, setLoggedIn] = useState<boolean>(false);
    const [allMatches, setAllMatches] = useState<Match[]>([]);
    const [match, setMatch] = React.useState<Match>();

    const handleSetMatch= (match: Match) => {
        setMatch(match);
    }

    useEffect(() => {
        const fetchMatches = async () => {
            try{
                const data = await getMatches();
                setAllMatches(data);
            }catch (error){
                console.error("Error fetching matches:", error);
            }
        }
        

        fetchMatches();
    }, []);



    return (
            <Routes>
                <Route
                    path="/login"
                    element={<Login setUser={setUser} setLoggedIn={setLoggedIn} />}
                />
                <Route
                path="/signup"
                element={<SignUp setUser={setUser} setLoggedIn={setLoggedIn} />}
                />
                <Route path="/" element={<Dashboard userId={user} handleSetMatch={handleSetMatch} matches={allMatches} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn} ></Dashboard>} />
                <Route path="createbet" element={<CreateBet userId={user} match={match!} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn}/>}/>
                <Route path="/yourbets" element={<YourBets matches={allMatches} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn} user={user}/>}></Route>
            </Routes>
    );
}

export default App;