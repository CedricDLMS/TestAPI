using System.Security.Cryptography;
using testAPI.IServices;

namespace testAPI.Services
{
    public class RandomService : IRandomService
    {
        readonly Random random = new Random();
        public int GetRandom(int min=0, int max = 100)
        {
            return random.Next(min, max);
        }
    }
}
