using System;

namespace GUNAAPugetSound.ViewModels
{
    public class LayoutViewModel
    {
        public string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }
    }
}