using Quartz;
using RestSharp;
using System;
using System.Threading.Tasks;
using CircuitBreaker.Net.Exceptions;

namespace FarGalaxy.Api.Jobs
{
    public class KeepAliveJob : IJob
    {
        private static readonly RestClient Client = new RestClient("");

        public async Task Execute(IJobExecutionContext context)
        {
            var day = new Random().Next(1, 365 * 10);
            RestRequest request = new RestRequest($"clima/{day}", Method.GET);

            CircuitBreaker.Net.CircuitBreaker circuitBreaker = new CircuitBreaker.Net.CircuitBreaker(
                TaskScheduler.Default,
                3,
                TimeSpan.FromMilliseconds(100),
                TimeSpan.FromMilliseconds(10000));

            try
            {
                await Client.ExecuteGetTaskAsync(request);
            }
            catch (CircuitBreakerOpenException)
            {
            }
            catch (CircuitBreakerTimeoutException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}