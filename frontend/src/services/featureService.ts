import axios from "axios";

const API_URL = "http://localhost:8080/api/Feature";
export const getFeatureFlag = async (flag: string): Promise<boolean> => {
    try {
        const requestURL = `${API_URL}?featureName=${flag}`; // Adjust the endpoint as needed
        const response = await axios.get(requestURL);

        return response.data
    } catch (error) {
        console.error("Error fetching user bets:", error);
        return false;
    }
};