using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_BusinessLogic
{
    public interface IDataBaseEngine
    {
        bool CheckRegion(string regionName);
        bool CheckSubjectAndRegion(string regionName, string subjectName);
        CountrySide CreateRegion(string regionName);
        SubjectOfTheRegion CreateSubjectOfTheRegion(string subjectName, string regionName);
        void DeleteSubject(string nameOfSubject, string nameOfRegion);
        CountrySide GetCountrySide(string nameOfRegion);
        SubjectOfTheRegion GetSubject(string nameOfSubject, CountrySide countrySide);

    }
}
