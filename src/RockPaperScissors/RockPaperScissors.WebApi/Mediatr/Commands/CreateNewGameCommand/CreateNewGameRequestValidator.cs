using FluentValidation;

namespace RockPaperScissors.WebApi.Mediatr.Commands.CreateNewGameCommand;

public class CreateNewGameRequestValidator : AbstractValidator<CreateNewGameRequest>
{
    public CreateNewGameRequestValidator()
    {
        RuleFor(r => r.Creator)
            .NotEmpty()
            .WithMessage("Имя создателя не должно быть пустым.");
    }
}