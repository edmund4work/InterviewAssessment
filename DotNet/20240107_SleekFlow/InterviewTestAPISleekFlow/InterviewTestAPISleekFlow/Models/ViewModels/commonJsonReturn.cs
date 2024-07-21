using System;
namespace InterviewTestAPISleekFlow.Models.ViewModels
{
	public class commonJsonReturn
	{
		public string returnStatus { get; set; } // (s) success or (f) fail, can be more.
		public string returnMsg { get; set; }
		public object? returnDataObject { get; set; }
	}
}

