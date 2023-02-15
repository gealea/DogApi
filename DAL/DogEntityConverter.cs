using DogApi.BLL.Model;
using DogApi.DAL.Entities;

namespace DogApi.DAL;

public static class DogEntityConverter
{
    public static Dog ConvertDogEntityToModel(DogEntity dogEntity)
    {
        return new Dog(
            guiId: dogEntity.GuiId,
            name: dogEntity.Name,
            breed: dogEntity.Breed,
            birthDate: dogEntity.BirthDate);
    }

    public static DogEntity ConvertDogEntityToModel(Dog dog)
    {
        return new DogEntity(
            guiId: dog.GuiId,
            name: dog.Name,
            breed: dog.Breed,
            birthDate: dog.BirthDate);
    }

    public static DogEntity ConvertLineToDogEntity(string dogLine)
    {
        var dogLineSplit = dogLine.Split(';');
        return new DogEntity(guiId: Guid.Parse(dogLineSplit[0]),
            birthDate: DateTime.Parse(dogLineSplit[1]),
            breed: dogLineSplit[2],
            name: dogLineSplit[3]);
    }
}