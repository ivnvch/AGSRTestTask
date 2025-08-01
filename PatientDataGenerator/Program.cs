/*using System.Net.Http.Json;
using AGSRTestTask.Application.Patients.Commands.Create;
using Bogus;
using PatientDataGenerator;

const string ApiBaseUrl = "https://localhost:7239/api/v1/patient/batch"; // Endpoint для пакетной вставки
const int NumberOfPatientsToGenerate = 100;

Console.WriteLine($"Запуск генерации и добавления {NumberOfPatientsToGenerate} пациентов...");

var patientsToCreate = new List<CreatePatientCommand>();
for (int i = 0; i < NumberOfPatientsToGenerate; i++)
{
    patientsToCreate.Add(GeneratePatient());
}

using (var httpClient = new HttpClient())
{
    httpClient.Timeout = TimeSpan.FromMinutes(5);

    var listCommand = new CreatePatientListCommand(listPatients: patientsToCreate);

    var success = await AddPatientsBatchAsync(httpClient, listCommand);

    if (success)
    {
        Console.WriteLine($"Успешно добавлено {NumberOfPatientsToGenerate} пациентов в одном запросе.");
    }
    else
    {
        Console.WriteLine($"Произошла ошибка при пакетном добавлении пациентов. Смотрите детали выше.");
    }
}

Console.WriteLine("Генерация и добавление пациентов завершены.");
Console.ReadKey();

static CreatePatientCommand GeneratePatient()
{
    var faker = new Faker<FakerDTO>()
        .RuleFor(p => p.FirstName, f => f.Name.FirstName())
        .RuleFor(p => p.LastName, f => f.Name.LastName())
        .RuleFor(p => p.MiddleName, f => f.Name.FirstName())
        .RuleFor(p => p.Use, f => f.PickRandom("official", "nickname", "maiden")) 
        .RuleFor(p => p.Gender, f => f.PickRandom("Other")) 
        .RuleFor(p => p.DateOfBirth, f => f.Date.Past(50, DateTime.Now.AddYears(-18)).ToUniversalTime())
        .RuleFor(p => p.Active, f => f.Random.Bool());

    var response =  faker.Generate();

    CreatePatientCommand command = new CreatePatientCommand(Gender: response.Gender, DateOfBirth: response.DateOfBirth,
        Active: response.Active, LastName: response.LastName, FirstName: response.FirstName, MiddleName: response.MiddleName, Use: response.Use);
    
    return command;
}

static async Task<bool> AddPatientsBatchAsync(HttpClient httpClient, CreatePatientListCommand listCommand)
{
    try
    {
        var response = await httpClient.PostAsJsonAsync(ApiBaseUrl, listCommand);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"API Response: {await response.Content.ReadAsStringAsync()}");
            return true;
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.Error.WriteLine($"Ошибка API: {response.StatusCode}");
            Console.Error.WriteLine($"Детали ошибки: {errorContent}");
            return false;
        }
    }
    catch (HttpRequestException ex)
    {
        Console.Error.WriteLine($"Сетевая ошибка при запросе к API: {ex.Message}");
        return false;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Неизвестная ошибка: {ex.Message}");
        return false;
    }
}*/