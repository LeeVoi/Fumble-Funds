import axios from "axios";
import {Match} from "../models/Match.ts";

const API_URL = "https://fumble-funds-6f817bf2c96d.herokuapp.com/api"; 

export const getMatches = async (): Promise<Match[]> => {
    try {
        const requestURL = `${API_URL}/Matches`; 
        const response = await axios.get(requestURL);
        return response.data;
    } catch (error) {
        console.error("Error fetching matches:", error);
        throw error; 
    }
};

export const getPopularMatches = async (count: number): Promise<Match[]> => {
    try {
        const requestURL = `http://localhost:8080/api/Matches/popular?count=${count}`; // Adjust the endpoint as needed
        const response = await axios.get(requestURL);
        return response.data;
    } catch (error) {
        console.error("Error fetching popular matches:", error);
        throw error; 
    }
}