import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { useState } from "react";
import "./App.css";
import Home from "./pages/Home.tsx";
import Login from "./pages/Login.tsx";
import SignUp from "./pages/SignUp.tsx";

function App() {
    const [user, setUser] = useState<number>(-1);
    const [loggedIn, setLoggedIn] = useState<boolean>(false);



    return (
        <Router>
            <Routes>
                <Route
                    path="/"
                    element={<Home loggedIn={loggedIn} setLoggedIn={setLoggedIn} setUser={setUser} />}
                />
                <Route
                    path="/login"
                    element={<Login setUser={setUser} setLoggedIn={setLoggedIn} />}
                />
                <Route
                path="/signup"
                element={<SignUp setUser={setUser} setLoggedIn={setLoggedIn} />}
                />
            </Routes>
        </Router>
    );
}

export default App;