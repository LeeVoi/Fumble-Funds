import axios from "axios";
import {BetPost} from "../models/BetPost.ts";

const API_URL = "http://localhost:8080/api/Bets"; // Replace with your API endpoint

// Fetch matches from the API
export const createBet = async (dto: BetPost): Promise<BetPost> => {
    try {
        console.log(dto);
        const requestURL = `${API_URL}`; // Adjust the endpoint as needed
        const response = await axios.post(requestURL, dto); // Send POST request with bet as the body
        return response.data;
    } catch (error) {
        console.error("Error posting bet:", error);
        throw error; // Re-throw the error to handle it in the calling code
    }
};