import axios from "axios";

const API_URL = "http://localhost:8080/api/User"; // Replace with your API endpoint

// Fetch matches from the API
export const login = async (email: string,  password: string): Promise<number> => {
    try {
        const requestURL = `${API_URL}/signin`; // Adjust the endpoint as needed
        const response = await axios.post(requestURL, { email, password });
        return response.data;
    } catch (error) {
        console.error("Error during login:", error);
        throw error; // Re-throw the error to handle it in the calling code
    }
};

export const signup = async (email: string,  password: string): Promise<number> => {
    try{
        const requestURL = `${API_URL}/create`;
        const username = "User";
        const response = await axios.post(requestURL, {username, email, password });
        return response.data;
    }catch(error){
        console.error("Error during signup:", error);
        throw error; // Re-throw the error to handle it in the calling code
    }
}