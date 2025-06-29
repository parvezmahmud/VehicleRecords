using VehicleRecords.Models;

namespace VehicleRecords.Repositories;

public interface IVehicleRepo
{
    IEnumerable<Vehicles> GetAllVehicles();
    Vehicles IndividualVehicle(int vehicleId);
    void AddVehicle(Vehicles vehicle);
    void UpdateVehicle(Vehicles vehicle);
    void DeleteVehicle(int vehicleId);
}