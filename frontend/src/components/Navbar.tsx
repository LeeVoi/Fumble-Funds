import { useNavigate } from "react-router-dom";
import logo from "../assets/logo.png";

interface NavbarProps {
    loggedIn: boolean;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
    setUser: React.Dispatch<React.SetStateAction<number>>;
}

const Navbar: React.FC<NavbarProps> = ({ loggedIn, setLoggedIn, setUser }) => {
    const navigate = useNavigate();

    const toggleLoggedIn = () => {
        if (loggedIn) {
            setLoggedIn(false);
            setUser(-1);
        } else {
            navigate("/login");
        }
    };

    return (
        <div className="navbar">
            <img src={logo} className="logo" alt="Logo" />
            <div className="navbar-button-bar">
                <button className="navbar-button">Dashboard</button>
                {loggedIn && <button className="navbar-button">Your Bets</button>}
            </div>
            <button className="navbar-login" onClick={toggleLoggedIn}>
                {loggedIn ? "Logout" : "Login"}
            </button>
        </div>
    );
};

export default Navbar;