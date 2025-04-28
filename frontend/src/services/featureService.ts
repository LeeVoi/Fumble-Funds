import axios from "axios";

const API_URL = "https://fumble-funds-6f817bf2c96d.herokuapp.com/api/Feature";
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