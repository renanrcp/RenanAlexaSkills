using Xunit;

namespace LolEsportsSkill.UnitTests;

public class TextFormatterTest
{
    [Fact]
    public void ShouldConcatenateTwoTeamsForFormatGameDay()
    {
        // Arrange
        var team1 = "team1";
        var team2 = "team2";
        var gameDate = new DateTime(2019, 1, 1, 15, 0, 0);

        // Act
        var result = TextFormatter.FormatGameDay(team1, team2, gameDate);

        // Assert
        Assert.Equal("Hoje tem jogo entre team1 e team2 às 15 horas", result);
    }
}
