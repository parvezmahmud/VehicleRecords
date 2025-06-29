using Newtonsoft.Json;
using VehicleRecords.Models;
using VehicleRecords.Repositories;
using Newtonsoft.Json.Serialization;
namespace VehicleRecords.SampleData;

public static class AddSampleData
{
    public static void AddVehiclesSampleData()
    {
        string path = "/home/pm/Dotnet/VehicleRecords/VehicleRecords/SampleData/VehiclesSample.json";
        var db = VehiclesDB.vehicles;
        using (StreamReader sr = new StreamReader(path))
        {
            string json = sr.ReadToEnd();
            List<Vehicles> sampleVehicles = JsonConvert.DeserializeObject<List<Vehicles>>(json);
            foreach (Vehicles vehicle in sampleVehicles)
            {
                db.Add(vehicle);
            }
        }
    }
}