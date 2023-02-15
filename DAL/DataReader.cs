using DogApi.BLL.Model;
using DogApi.DAL.Entities;

namespace DogApi.DAL;

public interface IDataReader
{
    Dog? GetDog(Guid guid);

    IList<Dog>? GetDogs();

}

public class DataReader : IDataReader
{
    public static readonly string PathToCsvFile = Path.Combine(Directory.GetCurrentDirectory(), "dogs.csv");

    public Dog? GetDog(Guid guid)
    {
        if (!File.Exists(PathToCsvFile))
        {
            return null;
        }

        var dogEntity = GetDogEntities().FirstOrDefault(x => x.GuiId == guid);
        return dogEntity == null ? null : DogEntityConverter.ConvertDogEntityToModel(dogEntity);
    }

    public IList<Dog>? GetDogs()
    {
        return !File.Exists(PathToCsvFile) ? null : GetDogEntities().Select(DogEntityConverter.ConvertDogEntityToModel).ToList();
    }

    private IList<DogEntity> GetDogEntities()
    {
        return ReadLines().Select(DogEntityConverter.ConvertLineToDogEntity).ToList();
    }

    private static string[] ReadLines()
    {
        return File.ReadAllLines(PathToCsvFile);
    }

   
}