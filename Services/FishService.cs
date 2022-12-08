using FishIdentifier.Models;

namespace FishIdentifier.Services;

public static class FishService
{
  static List<Fish> Fishes { get; }
  static int nextId = 3;
  static FishService()
  {
    Fishes = new List<Fish>
    {
      new Fish { Id = 1, Name = "Trout", Freshwater = false },
      new Fish { Id = 1, Name = "Grayling", Freshwater = true }
    };
  }
  public static List<Fish> GetAll() => Fishes;
  public static Fish? Get(int id) => Fishes.FirstOrDefault(f => f.Id == id);
  public static void Add(Fish fish)
  {
    fish.Id = nextId++;
    Fishes.Add(fish);
  }
  public static void Delete(int id)
  {
    var fish = Get(id);
    if(fish is null)
      return;
    
    Fishes.Remove(fish);
  }
  public static void Update(Fish fish)
  {
    var index = Fishes.FindIndex(f => f.Id == fish.Id);
    if (index == -1)
      return;

    Fishes[index] = fish;
  }
}
