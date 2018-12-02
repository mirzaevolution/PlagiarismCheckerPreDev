using FluentScheduler;
namespace StringReverseService
{
    public class StringReverseJob : IJob
    {
        public void Execute()
        {
            ReversePeriodic.Process();
        }
    }
}
