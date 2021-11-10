namespace Level.Other
{
    public interface IObjectPoolModel : IObjectPool
    {
        void SetElementActive(string id, bool isActive);
    }
}