namespace RentalCar.Security
{
    public class JwtSettings
    {
        public JwtSettings(string secret, int ttlMinutes)
        {
            Secret = secret;
            TTLMinutes = ttlMinutes;
        }
        public string Secret { get; init; }
        public int TTLMinutes { get; set; }
    }
}
