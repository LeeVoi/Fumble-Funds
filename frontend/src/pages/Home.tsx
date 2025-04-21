import * as React from "react";
import Navbar from "../components/Navbar.tsx";

interface HomeProps {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    setUser: React.Dispatch<React.SetStateAction<number>>;
}

const Home: React.FC<HomeProps> = ({ loggedIn, setLoggedIn, setUser }) => {
    return (
        <div className="container">
            <Navbar loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser} />
            <h1>Welcome to the Home Page</h1>
        </div>
    );
};

export default Home;