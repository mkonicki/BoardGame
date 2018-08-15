using BoardGame.Commands;
using System.Collections.Generic;

namespace BoardGame.Calculators
{
    public interface IGameResultCalculator
    {
        GameResult CalculateGameResult(GameEvent game, ICollection<MoveEvent> moves);
    }
}
