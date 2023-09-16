using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Repository_DemoVersion
{
    public class DataCreator
    {
        public async Task FillDB()
        {
            using (var db = new Context())
            {
                string[] regionNames = { "Московская область", "Краснодарский край", "Алтайский край" };
                string[] unit1Names = { "Москва", "Химки", "Подольск", "Пушкино", "Люберцы" };
                string[] unit2Names = { "Краснодар", "Сочи", "Анапа", "Туапсе", "Геленджик" };
                string[] unit3Names = { "Барнаул", "Бийск", "Белокуриха", "Яровое", "Тальменка" };
                foreach (var v in regionNames)
                {
                    var countrySide = DataBaseEngine.Instance.CreateRegion(v);
                    if (v == regionNames[0])
                    {
                        foreach (var v1 in unit1Names)
                            if (!db.SubjectOfTheRegions.Any(x => x.NameOfSubject == v1 && x.Region.NameOfRegion == v))
                            {
                                var unit = DataBaseEngine.Instance.CreateSubjectOfTheRegion(v1, v);
                            }
                    }
                    else if (v == regionNames[1])
                    {
                        foreach (var v1 in unit2Names)
                            if (!db.SubjectOfTheRegions.Any(x => x.NameOfSubject == v1 && x.Region.NameOfRegion == v))
                            {
                                var unit = DataBaseEngine.Instance.CreateSubjectOfTheRegion(v1, v);
                            }
                    }
                    else
                    {
                        foreach (var v1 in unit3Names)
                            if (!db.SubjectOfTheRegions.Any(x => x.NameOfSubject == v1 && x.Region.NameOfRegion == v))
                            {
                                var unit = DataBaseEngine.Instance.CreateSubjectOfTheRegion(v1, v);
                            }
                    }
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
