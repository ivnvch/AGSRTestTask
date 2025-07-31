using System.Net.Http.Json;
using AGSRTestTask.Application.Patients.Commands.Create;
using AGSRTestTask.Generator.Abstraction;

namespace AGSRTestTask.Generator.Seeds;

public class HttpPatientBatchSender : IPatientBatchSender
{
    private readonly HttpClient _httpClient;
    private readonly string _endpoint;
    
    public HttpPatientBatchSender(string endpoint)
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
        _endpoint = endpoint;
    }
    public async Task<bool> SendBatchAsync(List<CreatePatientCommand> patients)
    {
        try
        {
            var command = new CreatePatientListCommand(patients);
            var response = await _httpClient.PostAsJsonAsync(_endpoint, command);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API OK: {await response.Content.ReadAsStringAsync()}");
                return true;
            }

            Console.Error.WriteLine($"API Error: {response.StatusCode}");
            Console.Error.WriteLine(await response.Content.ReadAsStringAsync());
            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Ошибка отправки: {ex.Message}");
            return false;
        }
    }
}