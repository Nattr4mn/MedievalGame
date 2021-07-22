public interface IFarmObject 
{

    int Level { get; }
    float Production { get; }
    float Water { get; }
    bool Occupied { get; }
    bool CanCollect { get; }
    string ÑurrentPopulation { get; }
    PlayerItems PlayerItems { get; }

    void Fill(Animal animalName, Item food);
    void Collecting();
    void PourWater(float value);
    void Saturate();
}
