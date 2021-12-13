using FluentValidation;
using SportWebSite.Domain.Entities;

namespace SportWebSite.Domain.Validators
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Location).NotEmpty().Length(1, 40);
			RuleFor(x => x.Gender).NotNull();
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Name).NotEmpty().Length(1, 50);
		}
	}
}
