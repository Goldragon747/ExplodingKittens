using System.Collections.Generic;
using System.Linq;

namespace ExplodingKittens
{
	public class ActionResponse
	{
		private List<Message> _messages;

		public Writers.IOutputWriter Writer;

		public bool IsSuccessful
		{
			get
			{
				return (_messages.Where(m => m.Severity == Enums.Severity.Error).Count() <= 0);
			}
		}

		public bool HasMessages
		{
			get
			{
				return (_messages.Where(m => m.Severity == Enums.Severity.Info).Count() > 0);
			}
		}

		public string FirstErrorMessage
		{
			get
			{
				Message err = _messages.Where(m => m.Severity == Enums.Severity.Error).FirstOrDefault();

				return err == null ? "" : err.Text;
			}
		}

		public ActionResponse()
		{
			Writer = new Writers.ConsoleWriter();

			_messages = new List<Message>();
		}

		public ActionResponse(Writers.IOutputWriter writer)
			: this()
		{
			Writer = writer;
		}

		public ActionResponse(Message message)
			: this()
		{
			_messages.Add(message);
		}

		public void AddError(string message)
		{
			_messages.Add(new Message(Enums.Severity.Error, message));
		}

		public void AddMessage(string message)
		{
			_messages.Add(new Message(Enums.Severity.Info, message));
		}

		/// <summary>
		/// Print any messages associated with the response
		/// </summary>
		public void PrintMessages()
		{
			if (HasMessages)
			{
				foreach (Message message in _messages.Where(m => m.Severity == Enums.Severity.Info))
				{
					Writer.WriteLine(message.Text);
				}

				Writer.WriteLine();
			}
		}

		/// <summary>
		/// Print any errors associated with the response
		/// </summary>
		public void PrintErrors()
		{
			if (!IsSuccessful)
			{
				foreach (Message message in _messages.Where(m => m.Severity == Enums.Severity.Error))
				{
					Writer.WriteLine(message.Text);
				}

				Writer.WriteLine();
			}
		}

		public void PrintAll()
		{
			Writer.WriteLine();
			PrintErrors();
			PrintMessages();
		}
	}
}
