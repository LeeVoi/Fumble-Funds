import { Match } from "../models/Match.ts";
import { useState } from "react";
import { MatchOutcome } from "../models/MatchOutcome.ts";
import { createBet } from "../services/betService.ts";
import { BetPost } from "../models/BetPost.ts";
import Navbar from "./Navbar.tsx";
import * as React from "react";

interface CreateBetProps {
  userId: number;
  match: Match;
  loggedIn: boolean;
  setLoggedIn: React.Dispatch<React.SetStateAction<boolean>>;
  setUser: React.Dispatch<React.SetStateAction<number>>;
  popularEnabled: boolean;
}

const CreateBet: React.FC<CreateBetProps> = ({
  userId,
  match,
  loggedIn,
  setLoggedIn,
  setUser,
  popularEnabled,
}) => {
  const [betAmount, setBetAmount] = useState<number>();
  const [outcome, setOutcome] = useState<MatchOutcome>(MatchOutcome.HomeWin);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const bet: BetPost = {
      userId: userId,
      matchId: match!.id,
      amount: betAmount!,
      predictedOutcome: outcome,
    };

    try {
      const response = await createBet(bet);
      console.log("Bet created successfully:", response);
      setSuccessMessage("Bet placed successfully!");
      setTimeout(() => setSuccessMessage(null), 3000);
    } catch (error) {
      console.error("Error creating bet:", error);
    }
  };

  return (
    <div className="container">
      <Navbar
        loggedIn={loggedIn}
        setLoggedIn={setLoggedIn}
        setUser={setUser}
        popularEnabled={popularEnabled}
      />
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
          height: "100%",
        }}
      >
        <h1>{`${match!.homeTeam} vs ${match!.awayTeam}`}</h1>

        <form
          onSubmit={handleSubmit}
          style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            gap: "10px",
          }}
        >
          <label>
            Bet Amount:
            <input
              type="number"
              placeholder={"amount"}
              value={betAmount}
              onChange={(e) => setBetAmount(Number(e.target.value))}
              style={{ marginLeft: "10px" }}
            />
          </label>
          <label>
            Outcome:
            <select
              value={outcome}
              onChange={(e) => setOutcome(Number(e.target.value))}
              style={{ marginLeft: "10px" }}
            >
              <option value={MatchOutcome.HomeWin}>Home Win</option>
              <option value={MatchOutcome.AwayWin}>Away Win</option>
              <option value={MatchOutcome.Draw}>Draw</option>
            </select>
          </label>
          <button type="submit" style={{ marginTop: "10px" }}>
            Place Bet
          </button>
        </form>

        {successMessage && (
          <div
            style={{
              backgroundColor: "#a3c7c2",
              color: "white",
              padding: "10px 20px",
              borderRadius: "8px",
              marginTop: "20px",
              fontWeight: "bold",
            }}
          >
            {successMessage}
          </div>
        )}
      </div>
    </div>
  );
};

export default CreateBet;
