import { Routes, Route} from "react-router-dom";
import { useState } from "react";
import "./App.css";
import Login from "./pages/Login.tsx";
import SignUp from "./pages/SignUp.tsx";
import Dashboard from "./components/Dashboard.tsx";
import CreateBet from "./components/CreateBet.tsx";
import * as React from "react";
import {Match} from "./models/Match.ts";

function App() {
    const [user, setUser] = useState<number>(-1);
    const [loggedIn, setLoggedIn] = useState<boolean>(false);
    const [match, setMatch] = React.useState<Match>();

    const handleSetMatch= (match: Match) => {
        setMatch(match);
    }



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
                <Route path="/" element={<Dashboard userId={user} handleSetMatch={handleSetMatch} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn} ></Dashboard>} />
                <Route path="createbet" element={<CreateBet userId={user} match={match!} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn}/>}/>
            </Routes>
    );
}

export default App;