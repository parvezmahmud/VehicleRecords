using VehicleRecords.Repositories;
using VehicleRecords.Models;
namespace VehicleRecords;

class Program
{
    static void Main(string[] args)
    {
        Display();
    }

    static void Display()
    {
        Console.WriteLine("1. Show all vehicles\n2.Add Vehicle\n3.Update Vehicle\n4.Delete Vehicle");
        int choice = int.Parse(Console.ReadLine());
        ManageVehicles(choice);
        
        
    }

    static void ManageVehicles(int choice)
    {
        VehiclesRepo repo = new VehiclesRepo();
        switch (choice)
        {
            case 0:
                Console.WriteLine("Wrong");
                break;
            case 1:
                try
                {
                    
                    var allVehicles = repo.GetAllVehicles();
                    foreach (var vehicle in allVehicles)
                    {
                        Console.WriteLine(
                            $"Model: {vehicle.VehicleModel}, Date: {vehicle.VehicleDate}, Registration Number: {vehicle.RegistrationNumber}, Owner: {vehicle.Owner}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Environment.Exit(1);
                }
                Display();
                break;
            case 2:
                try
                {
                    Console.WriteLine("Enter vehicle model");
                    string? model = Console.ReadLine();
                    Console.WriteLine("Enter vehicle registration number");
                    string? registrationNumber = Console.ReadLine();
                    Console.WriteLine("Enter vehicle registration date");
                    string? vehicleDate = Console.ReadLine();
                    Console.WriteLine("Enter vehicle owner");
                    string? owner = Console.ReadLine();
                    int maxId =VehiclesDB.vehicles.Any()? VehiclesDB.vehicles.Max(x => x.VehicleId): 0;
                    Vehicles addNew = new Vehicles
                    {
                        VehicleId = maxId + 1,
                        VehicleModel = model != null? model: null,
                        VehicleDate = vehicleDate,
                        RegistrationNumber = registrationNumber,
                        Owner = owner
                    };
                    repo.AddVehicle(addNew);
                    Console.WriteLine("Vehicle added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Environment.Exit(1);
                }
                Display();
                break;
            case 3:
                try
                {
                    Console.WriteLine("Enter vehicle ID");
                    int vehicleID = int.Parse(Console.ReadLine());
                    var item = repo.IndividualVehicle(vehicleID);
                    Console.WriteLine($"Old Model: {item.VehicleModel}");
                    Console.Write("New Model: ");
                    string newModel = Console.ReadLine();
                    Console.WriteLine($"Old Registration Number: {item.RegistrationNumber}");
                    Console.Write("New Registration Date: ");
                    string newRegistrationNumber = Console.ReadLine();
                    Console.WriteLine($"Old Registration Date: {item.VehicleDate}");
                    Console.Write("New Registration Date: ");
                    string newVehicleDate = Console.ReadLine();
                    Vehicles updateVehicle = new Vehicles
                    {
                        VehicleId = item.VehicleId,
                        VehicleModel = newModel,
                        RegistrationNumber = newRegistrationNumber,
                        VehicleDate = newVehicleDate,
                        Owner = item.Owner,
                        
                    };
                    repo.UpdateVehicle(updateVehicle);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Display();
                break;
            case 4:
                Console.Write("Enter vehicle ID to delete: ");
                int deleteId = int.Parse(Console.ReadLine());
                repo.DeleteVehicle(deleteId);
                Display();
                break;
            default:
                Console.WriteLine("Wrong");
                break;
        }
    }
}