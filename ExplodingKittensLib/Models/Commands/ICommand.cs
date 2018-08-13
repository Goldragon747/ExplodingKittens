
namespace ExplodingKittensLib.Models.Commands
{
	public interface ICommand
	{
		Enums.Command CommandType { get; }
		string Description { get; }

		ActionResponse Execute();
	}
}
