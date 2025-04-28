import axios from "axios";
import {BetPost} from "../models/BetPost.ts";
import {ReturnedBet} from "../models/ReturnedBet.ts";

const API_URL = "https://fumble-funds-6f817bf2c96d.herokuapp.com/api/Bets"; // Replace with your API endpoint

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

export const getUserBets = async (userId: number): Promise<ReturnedBet[]> => {
    try {
        const requestURL = `${API_URL}?userId=${userId}`; // Adjust the endpoint as needed
        const response = await axios.get(requestURL);

        // Map the response data to BetPost objects
        const bets: ReturnedBet[] = response.data.map((bet: ReturnedBet) => ({
            id: bet.id,
            userId: bet.userId,
            matchId: bet.matchId,
            amount: bet.amount,
            predictedOutcome: bet.predictedOutcome,
            placedAt: new Date(bet.placedAt), // Convert placedAt to a Date object
        }));

        return bets;
    } catch (error) {
        console.error("Error fetching user bets:", error);
        throw error;
    }
};