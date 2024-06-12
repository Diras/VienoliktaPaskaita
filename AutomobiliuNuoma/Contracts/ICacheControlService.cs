namespace AutomobiliuNuoma.Contracts
{
    public interface ICacheControlService
    {
        Task Start();
        void Stop();
    }
}