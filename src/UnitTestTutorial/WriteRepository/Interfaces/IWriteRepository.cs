namespace UnitTestTutorial.WriteRepository.Interfaces
{
    public interface IWriteRepository<T> where T : Model.Entity
    {
         void Add();
         void Update();
    }
}