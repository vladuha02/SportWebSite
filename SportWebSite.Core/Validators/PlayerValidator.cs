using FluentValidation;
using SportWebSite.Domain.Entities;

namespace SportWebSite.Domain.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
	{
		public PlayerValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).NotEmpty().Length(1, 60);
			RuleFor(x => x.Position).NotEmpty().Length(2, 30);
			RuleFor(x => x.DateOfBirth).NotEmpty();
			RuleFor(x => x.CountryOfBirth).NotEmpty().Length(1, 30);
			RuleFor(x => x.Nationality).NotEmpty().Length(1, 30);
			RuleFor(x => x.Role).NotEmpty().Length(1, 30);
		}
	}
}
