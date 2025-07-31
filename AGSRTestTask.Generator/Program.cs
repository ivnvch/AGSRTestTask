using AGSRTestTask.Application.Patients.Commands.Create;
using AGSRTestTask.Generator.Abstraction;
using AGSRTestTask.Generator.Seeds;

const int NumberOfPatientsToGenerate = 100;

Console.WriteLine("Ожидание запуска Web API...");
await Task.Delay(TimeSpan.FromSeconds(5));

Console.WriteLine($"Генерация и добавка {NumberOfPatientsToGenerate} пациентов...");

IPatientGenerator generator = new BogusPatientGenerator();
IPatientBatchSender sender = new HttpPatientBatchSender("https://localhost:7239/api/v1/patient/batch");

var patients = new List<CreatePatientCommand>();
for (int i = 0; i < NumberOfPatientsToGenerate; i++) 
    patients.Add(generator.Generate());

bool result = await sender.SendBatchAsync(patients);

Console.WriteLine(result ? $"Успешно добавлено {NumberOfPatientsToGenerate} пациентов." : $"Ошибка при добавлении пациентов.");

Console.ReadKey();