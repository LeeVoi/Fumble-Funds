import * as React from "react";
import Navbar from "../components/Navbar.tsx";
import {useEffect} from "react";
import Dashboard from "../components/Dashboard.tsx";

interface HomeProps {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    userId: number;
    setUser: React.Dispatch<React.SetStateAction<number>>;
}

const Home: React.FC<HomeProps> = ({ loggedIn, setLoggedIn, userId, setUser }) => {

    useEffect(() => {
        
    }, []);
    return (
        <div className="container">
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser} />
            <Dashboard userId={userId}></Dashboard>
        </div>
    );
};

export default Home;