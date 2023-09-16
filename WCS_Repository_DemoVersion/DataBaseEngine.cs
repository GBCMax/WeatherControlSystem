using WCS_BusinessLogic;

namespace WCS_Repository_DemoVersion;

public class
    DataBaseEngine: IDataBaseEngine
{
    private static readonly Lazy<DataBaseEngine> instance = new(() => new DataBaseEngine());

    private DataBaseEngine()
    {
    }

    public static DataBaseEngine Instance => instance.Value;

    public bool CheckRegion(string regionName)
    {
        using (var db = new Context())
        {
            if (db.Regions.Any(x => x.NameOfRegion == regionName))
                return true;
            return false;
        }
    }

    public bool CheckSubjectAndRegion(string regionName, string subjectName)
    {
        using (var db = new Context())
        {
            if (db.Regions.Any(x => x.NameOfRegion == regionName) &&
                db.SubjectOfTheRegions.Any(x => x.NameOfSubject == subjectName && x.RegionId == x.Region.IdRegion))
                return true;
        }

        return false;
    }

    private RegionForEFCore GetRegionEfCore(string regionName)
    {
        using (var db = new Context())
        {
            return db.Regions.First(x => x.NameOfRegion == regionName);
        }
    }

    public CountrySide GetCountrySide(string nameOfRegion)
    {
        RegionForEFCore region = null;
        using (var db = new Context())
        {
            if (!db.Regions.Any(x => x.NameOfRegion == nameOfRegion))
            {
                
                db.Regions.Add(region);
                db.SaveChanges();
            }
            else
            {
                region = GetRegionEfCore(nameOfRegion);
            }
            return new CountrySide(region.IdRegion, region.NameOfRegion);
        }
    }

    public SubjectOfTheRegion GetSubject(string nameOfSubject, CountrySide countrySide)
    {
        RegionForEFCore regionForEFCore = GetRegionEfCore(countrySide.NameOfRegion);
        SubjectOfTheRegionForEFCore subjectOfTheRegionForEFCore = null;
        using (var db = new Context())
        { 
            if(!db.SubjectOfTheRegions.Any(x => x.NameOfSubject == nameOfSubject))
            {
                subjectOfTheRegionForEFCore = new SubjectOfTheRegionForEFCore
                {
                    NameOfSubject = nameOfSubject,
                    RegionId = regionForEFCore.IdRegion,
                    Region = regionForEFCore
                };
            }
            else
            {
                subjectOfTheRegionForEFCore = GetSubjectEfCore(nameOfSubject);
            }
            var subjectOfTheRegion =
                new SubjectOfTheRegion(subjectOfTheRegionForEFCore.IdSubject, subjectOfTheRegionForEFCore.NameOfSubject);
            countrySide.AddUnit(subjectOfTheRegion);
            return subjectOfTheRegion;
        }
    }

    private SubjectOfTheRegionForEFCore GetSubjectEfCore(string subjectName)
    {
        using (var db = new Context())
        {
            return db.SubjectOfTheRegions.Where(x => x.NameOfSubject == subjectName).First();
        }
    }

    private List<WeatherServiceForEFCore> GetWeatherEfCore(SubjectOfTheRegionForEFCore subject)
    {
        using (var db = new Context())
        {
            return db.WeatherServices.Where(x => x.SubjectOfTheRegion == subject).ToList();
        }
    }

    public WeatherServiceGenerator GetWeatherServiceGenerator(string nameOfSubject)
    {
        SubjectOfTheRegionForEFCore subjectOfTheRegionForEFCore = GetSubjectEfCore(nameOfSubject);
        List<WeatherServiceForEFCore> weather = GetWeatherEfCore(subjectOfTheRegionForEFCore);
        using (var db = new Context())
        {
            var wsg = new WeatherServiceGenerator();
            for (var i = 0; i < weather.Count; i++)
            {
                wsg.DateTimes[i] = weather[i].Date;
                wsg.Temperatures[i] = weather[i].Temperature;
                wsg.AtmosphericPressures[i] = weather[i].Pressure;
                wsg.WindSpeeds[i] = weather[i].WindSpeed;
                wsg.Precipitations[i] = weather[i].Precipitation;
            }
            return wsg;
        }
    }

    public CountrySide CreateRegion(string regionName)
    {
        using (var db = new Context())
        {
            if (!db.Regions.Any(x => x.NameOfRegion == regionName))
            {
                var countrySide = new CountrySide(-1, regionName);
                var regionForEfCore = new RegionForEFCore
                {
                    NameOfRegion = countrySide.NameOfRegion
                };
                db.Regions.Add(regionForEfCore);
                db.SaveChanges();
                return countrySide;
            }
            return GetCountrySide(regionName);
        }
    }

    public SubjectOfTheRegion CreateSubjectOfTheRegion(string subjectName, string regionName)
    {
        using (var db = new Context())
        {
            if (!db.SubjectOfTheRegions.Any(x => x.NameOfSubject == subjectName && x.Region.NameOfRegion == regionName))
            {
                CountrySide countrySide = GetCountrySide(regionName);
                RegionForEFCore regionForEfCore = GetRegionEfCore(countrySide.NameOfRegion);
                var subjectOfTheRegion = new SubjectOfTheRegion(-1, subjectName);
                countrySide.AddUnit(subjectOfTheRegion);
                var subject = new SubjectOfTheRegionForEFCore
                {
                    NameOfSubject = subjectOfTheRegion.NameOfSubject,
                    RegionId = regionForEfCore.IdRegion,
                    Region = regionForEfCore
                };
                db.SaveChanges();
                subject.Weather = CreateWeatherServiceForEfCore(subjectOfTheRegion.WeatherService, subject);
                db.SaveChanges();
                regionForEfCore.AddUnit(subject);
                db.Regions.Update(regionForEfCore);
                db.SubjectOfTheRegions.Add(subject);
                db.SaveChanges();
                return subjectOfTheRegion;
            }

            return GetSubject(subjectName, GetCountrySide(regionName));
        }
    }

    private List<WeatherServiceForEFCore> CreateWeatherServiceForEfCore(WeatherServiceGenerator weather,
        SubjectOfTheRegionForEFCore subjectOfTheRegion)
    {
        var wsffefc = new List<WeatherServiceForEFCore>();
        using (var db = new Context())
        {
            for (var i = 0; i < weather.DateTimes.Length; i++)
                if (!db.WeatherServices.Any(x =>
                        x.Date == weather.DateTimes[i] && x.SubjectOfTheRegion == subjectOfTheRegion))
                {
                    var weatherService = new WeatherServiceForEFCore
                    {
                        Date = weather.DateTimes[i],
                        Temperature = weather.Temperatures[i],
                        Pressure = weather.AtmosphericPressures[i],
                        WindSpeed = weather.WindSpeeds[i],
                        Precipitation = weather.Precipitations[i],
                        SubjectOfTheRegion = subjectOfTheRegion
                    };
                    wsffefc.Add(weatherService);
                    db.WeatherServices.Add(weatherService);
                }
        }

        return wsffefc;
    }
    public void DeleteSubject(string nameOfSubject, string nameOfRegion)
    {
        using (var db = new Context())
        {
            if (db.SubjectOfTheRegions.Any(x => x.NameOfSubject == nameOfSubject && x.Region.NameOfRegion == nameOfRegion))
            {
                CountrySide countrySide = GetCountrySide(nameOfRegion);
                SubjectOfTheRegion subjectOfTheRegion = GetSubject(nameOfSubject, countrySide);
                SubjectOfTheRegionForEFCore subjectOfTheRegionForEFCore = GetSubjectEfCore(subjectOfTheRegion.NameOfSubject);
                db.Remove(subjectOfTheRegionForEFCore);
                db.SaveChanges();
            }
        }
    }
}