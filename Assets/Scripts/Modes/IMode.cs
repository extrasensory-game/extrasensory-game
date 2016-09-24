public interface IMode
{
    void Init();
    void Update();
    bool IsFinished();
    void Deinit();
}