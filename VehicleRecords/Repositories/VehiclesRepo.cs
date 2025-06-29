using VehicleRecords.Models;

namespace VehicleRecords.Repositories;

public class VehiclesRepo: IVehicleRepo
{
    public IEnumerable<Vehicles> GetAllVehicles()
    {
        return VehiclesDB.vehicles;
    }

    public Vehicles IndividualVehicle(int vehicleId)
    {
        Vehicles searchedItem = VehiclesDB.vehicles.FirstOrDefault(x => x.VehicleId == vehicleId);
        return searchedItem!=null? searchedItem : null;
    }

    public void AddVehicle(Vehicles vehicle)
    {
        VehiclesDB.vehicles.Add(vehicle);
    }

    public void UpdateVehicle(Vehicles vehicle)
    {
        Vehicles existingItem = VehiclesDB.vehicles.FirstOrDefault(x => x.VehicleId == vehicle.VehicleId);
        VehiclesDB.vehicles.Remove(existingItem);
        VehiclesDB.vehicles.Add(vehicle);
    }

    public void DeleteVehicle(int vehicleId)
    {
        var existingItem = VehiclesDB.vehicles.FirstOrDefault(x => x.VehicleId == vehicleId);
        VehiclesDB.vehicles.Remove(existingItem);
    }
}