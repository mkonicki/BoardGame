using BoardGame.Commands;
using BoardGame.Data;
using System.Collections.Generic;

namespace BoardGame.Calculators
{
    public interface IGameResultCalculator
    {
        GameResult CalculateGameResult(GameEvent game, ICollection<MoveEvent> moves);
    }
}
