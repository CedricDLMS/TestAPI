namespace testAPI.IServices
{
    public interface IRandomService
    {
        int GetRandom(int min = 0, int max = 100);
    }
}
