import axios from "axios";
import {Match} from "../models/Match.ts";

const API_URL = "http://localhost:8080/api"; // Replace with your API endpoint

// Fetch matches from the API
export const getMatches = async (): Promise<Match[]> => {
    try {
        const requestURL = `${API_URL}/Matches`; // Adjust the endpoint as needed
        const response = await axios.get(requestURL);
        return response.data;
    } catch (error) {
        console.error("Error fetching matches:", error);
        throw error; // Re-throw the error to handle it in the calling code
    }
};

export const getPopularMatches = async (count: number): Promise<Match[]> => {
    try {
        const requestURL = `${API_URL}/Matches/popular?count=${count}`; // Adjust the endpoint as needed
        const response = await axios.get(requestURL);
        return response.data;
    } catch (error) {
        console.error("Error fetching popular matches:", error);
        throw error; // Re-throw the error to handle it in the calling code
    }
}