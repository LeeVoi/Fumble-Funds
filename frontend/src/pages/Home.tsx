import * as React from "react";
import Navbar from "../components/Navbar.tsx";
import Dashboard from "../components/Dashboard.tsx";
import {Route, Routes} from "react-router-dom";
import CreateBet from "../components/CreateBet.tsx";
import {Match} from "../models/Match.ts";

interface HomeProps {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    userId: number;
    setUser: React.Dispatch<React.SetStateAction<number>>;
}

const Home: React.FC<HomeProps> = ({ loggedIn, setLoggedIn, userId, setUser }) => {
    const [match, setMatch] = React.useState<Match>();
    
    const handleSetMatch= (match: Match) => {
        setMatch(match);
    }
    
    return (
        <div className="container">             
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser} />
            <Routes>
                <Route path="/" element={<Dashboard userId={userId} handleSetMatch={handleSetMatch} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn} ></Dashboard>} />
                <Route path="createbet" element={<CreateBet userId={userId} match={match!} setUser={setUser} setLoggedIn={setLoggedIn} loggedIn={loggedIn}/>}/>  
            </Routes>
            
        </div>
    );
};

export default Home;