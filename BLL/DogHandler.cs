using System.Globalization;
using DogApi.BLL.Model;
using DogApi.DAL;

namespace DogApi.BLL;

public interface IDogHandler
{
    Dog SaveNewDog(DogRequest dog);
    Dog? GetDog(Guid guid);
    IList<Dog> GetDogs();
}
public class DogHandler : IDogHandler
{
    private readonly IDataWriter _dataWriter;
    private readonly IDataReader _dataReader;
        
    public DogHandler(IDataWriter dataWriter, IDataReader dataReader)
    {
        _dataWriter = dataWriter;
        _dataReader = dataReader;
    }

    public Dog SaveNewDog(DogRequest dogRequest)
    {
        var dog = ConvertDogRequestToDog(dogRequest);
        _dataWriter.SaveNewDog(dog);
        return dog;
    }

    public Dog? GetDog(Guid guid)
    {
        return _dataReader.GetDog(guid);
    }

    public IList<Dog> GetDogs()
    {
        var dogs = _dataReader.GetDogs();
        return dogs ?? new List<Dog>();
    }

    private Dog ConvertDogRequestToDog(DogRequest dogRequest)
    {
        return new Dog(
            guiId: Guid.NewGuid(),
            name: dogRequest.Name,
            breed: dogRequest.Breed,
            birthDate: DateTime.ParseExact(s: dogRequest.BirthDate, format: "yyyy-mm-dd", provider: new DateTimeFormatInfo()));

    }
}

public static class DogHandlerFactory
{
    public static IDogHandler GetDogHandler()
    {
        return new DogHandler(new DataWriter(), new DataReader());
    }
}
