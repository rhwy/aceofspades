namespace EscapedConsole
{
	using System;
	
	public class Code
	{
		private string value;
		private string reset;
		
		public Code(string value,string reset = null)
		{
			this.value=value;
			this.reset=reset ?? value;
		}
		public override string ToString()
		{
			return this.value;
		}
		public string Reset {get { return reset;}}
	}
	
	
	public static class Codes
	{
		public static Code ClearScreen = new Code("\x1b[2J");
		public static Code TopLeft = new Code("\x1b[0;0H");
		public static Code Clean = new Code("\x1b[0m","\x1b[0m");
		public static Code Bold = new Code("\x1b[1m","\x1b[21m");
		public static Code Faint = new Code("\x1b[1m","\x1b[21m");
		public static Code Italic = new Code("\x1b[1m","\x1b[23m");
		public static Code Underline = new Code("\x1b[4m","\x1b[24m");
		public static Code Blink = new Code("\x1b[5m","\x1b[25m");
		public static Code Reverse = new Code("\x1b[7m","\x1b[27m");
		
		public static Func<Code,string,string> ToColor = (color,content) => 
		{
			return $"{color}{content}{Color.Reset}";		
		};
		
		public static Func<string,string> ToGrey = (content) => 
		{
			return ToColor(Color.Grey,content);		
		};
		
		public static class Cursor
		{
			public static Code SavePosition = new Code("\x1b[s");
			public static Code RestorePosition = new Code("\x1b[u");
			public static Code UpOne = new Code("\x1b[1A");
			public static Code BackOne = new Code("\x1b[1D");
		}
		
		public static class Color
		{
			public static Code Reset = new Code("\x1b[39m","\x1b[39m");
			
			public static Code Grey = new Code("\x1b[30m","\x1b[39m");
			public static Code Orange = new Code("\x1b[31m","\x1b[39m");
			public static Code Green = new Code("\x1b[32m","\x1b[39m");
			public static Code Yellow = new Code("\x1b[33m","\x1b[39m");
			public static Code Blue = new Code("\x1b[34m","\x1b[39m");
			public static Code Pink = new Code("\x1b[35m","\x1b[39m");
			public static Code Purple = new Code("\x1b[36m","\x1b[39m");
			public static Code White = new Code("\x1b[37m","\x1b[39m");
		}
		
		public static class Background
		{
			public static Code Reset = new Code("\x1b[49m","\x1b[49m");
			
			public static Code Grey = new Code("\x1b[40m","\x1b[49m");
			public static Code Orange = new Code("\x1b[41m","\x1b[49m");
			public static Code Green = new Code("\x1b[42m","\x1b[49m");
			public static Code Yellow = new Code("\x1b[43m","\x1b[49m");
			public static Code Blue = new Code("\x1b[44m","\x1b[49m");
			public static Code Pink = new Code("\x1b[45m","\x1b[49m");
			public static Code Purple = new Code("\x1b[46m","\x1b[49m");
			public static Code White = new Code("\x1b[47m","\x1b[49m");
		}
		
		
		
	}
	
	public static class SpecialChars
	{	
		public static class Fill
		{
			public static char SquareWithOrthogonalCrosshatchFill = '\u25A6';
			public static char SquareEmptySmall = '\u25A1';
		}
	}
}