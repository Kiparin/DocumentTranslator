using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Intarfaces
{
    public interface IDocument
    {
        public void Read(string path);
        public void Save(string path, string text);
        public int Count();
        public string GetPage(int page);
    }
}
