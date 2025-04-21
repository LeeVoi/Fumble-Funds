using System.ComponentModel.DataAnnotations;

public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username    { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email       { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // nav
        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }