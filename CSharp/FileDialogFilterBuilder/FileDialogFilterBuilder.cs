using System;
using System.Text;

namespace CodeSnippets
{
    public class FileDialogFilterBuilder
    {
        public interface ITextResources
        {
            string AllFiles { get; }
            string NameFormat { get; }
        }
        
        private class DefaultTextResources : ITextResources
        {
            public string AllFiles => "All files";
            public string NameFormat => "{0} ({1})";
        }
        
        private readonly StringBuilder _inner;
        private readonly ITextResources _textResources;
        
        public FileDialogFilterBuilder()
            : this(new DefaultTextResources())
        {
        }
        
        public FileDialogFilterBuilder(ITextResources textResources)
        {
            _inner = new StringBuilder();
            _textResources = textResources;
        }

        public void AddAllFiles()
        {
            Add(_textResources.AllFiles, "*.*");
        }

        public void Add(string name, params string[] patterns)
        {
            if (_inner.Length != 0)
                _inner.Append("|");

            var patternFilter = new StringBuilder();

            foreach(var pattern in patterns)
            {
                if(patternFilter.Length != 0)
                    patternFilter.Append(";");
                patternFilter.Append(pattern);
            }

            var text = string.Format(_textResources.NameFormat, name, patternFilter);
            _inner.Append($"{text}|{patternFilter}");
        }
        
        public override string ToString()
        {
            return _inner.ToString();
        }
    }
}