using ExtrasensoryGame;

public interface IMode
{
    void Init(Game game);
    void Update();
    bool IsFinished();
    void Deinit();
}