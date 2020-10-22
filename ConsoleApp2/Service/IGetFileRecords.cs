using ConsoleApp2.Model;
using System.Collections.Generic;

namespace ConsoleApp2.Service
{
    public interface IGetFileRecords
    {
        IEnumerable<Profile> GetFileDetails();
    }
}
