using System.Security.Cryptography;
using testAPI.IServices;

namespace testAPI.Services
{
    public class CryptoRandom : IRandomService
    {
        public int GetRandom(int min = 0, int max = 100)
        {
            int random = RandomNumberGenerator.GetInt32(min, max);

            return random;
        }
    }
}
