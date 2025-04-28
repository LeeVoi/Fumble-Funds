import {useState} from "react";
import {useNavigate} from "react-router-dom";
import {login} from "./../services/userService.ts";
import logo from "../assets/logo.png";


interface LoginProps {
    setUser: React.Dispatch<React.SetStateAction<number>>;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
}

const Login: React.FC<LoginProps> = ({setUser, setLoggedIn}) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleLoginClick = async () =>{
        const response = await login(email, password);
        setUser(response);
        setLoggedIn(true);
        navigate("/");
    }

    const handleSignup = () =>{
        navigate("/signup");
    }

    const navigateHome = () => {
        navigate("/")
    }

    return (
        <div className="login-container">
            <img onClick={navigateHome} src={logo} className="login-logo"/>
            <div className="login-box">
                <h1 className="heading">LOGIN</h1>
                <label className="input-label">Email</label>
                <input className="input" placeholder="email" onChange={(e) => setEmail(e.target.value)}></input>
                <label className="input-label">Password</label>
                <input className="input" placeholder="password" type="password" onChange={(e) => setPassword(e.target.value)}></input>
                <button className="login-button" disabled={!email.trim() || !password.trim()} onClick={handleLoginClick}>Login</button>
                <p>
                    Don't have an account?{" "}
                    <a href="#" className="signup-link" onClick={(e) => {e.preventDefault(); handleSignup();}}>
                        Sign up here!
                    </a>
                </p>
            </div>
            <div className="login-white-space"></div>
        </div>
    )
}

export default Login