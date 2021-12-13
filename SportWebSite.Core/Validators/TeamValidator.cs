using FluentValidation;
using SportWebSite.Domain.Entities;

namespace SportWebSite.Domain.Validators
{
	public class TeamValidator : AbstractValidator<Team>
	{
		public TeamValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.TeamName).NotNull().NotEmpty().Length(3, 25);
			RuleFor(x => x.SportType).NotNull().NotEmpty();
		}
	}
}
