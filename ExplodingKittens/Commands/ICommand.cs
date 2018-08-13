
namespace ExplodingKittens.Commands
{
	public interface ICommand
	{
		Enums.Commands.Command CommandType { get; }
		string Description { get; }

		ActionResponse Execute();
	}
}
