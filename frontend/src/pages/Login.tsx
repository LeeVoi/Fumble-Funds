import {useState} from "react";
import {useNavigate} from "react-router-dom";
import logo from "../assets/logo.png";


interface LoginProps {
    setUser: React.Dispatch<React.SetStateAction<number>>;
    setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
}

const Login: React.FC<LoginProps> = ({setUser, setLoggedIn}) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleLoginClick = () =>{
        console.log(email);
        console.log(password);
        setLoggedIn(true);
        setUser(1);
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