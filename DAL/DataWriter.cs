using DogApi.BLL.Model;
using DogApi.DAL.Entities;

namespace DogApi.DAL;

public interface IDataWriter
{
    void SaveNewDog(Dog dog);
}

public class DataWriter : IDataWriter
{
    public static readonly string PathToCsvFile = Path.Combine(Directory.GetCurrentDirectory(), "dogs.csv");
    public void SaveNewDog(Dog dog)
    {
        var dogEntity = DogEntityConverter.ConvertDogEntityToModel(dog);
        SaveDogEntityToFile(dogEntity);
    }

    private static void SaveDogEntityToFile(DogEntity dogEntity)
    {
        var dogEntityLine = $"{dogEntity.GuiId};{dogEntity.BirthDate};{dogEntity.Breed};{dogEntity.Name}{Environment.NewLine}";
        TextWriter tsw = new StreamWriter(PathToCsvFile, true);
        tsw.Write(dogEntityLine);
        tsw.Close();
    }
}