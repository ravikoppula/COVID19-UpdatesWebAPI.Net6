using Newtonsoft.Json;
using System.Globalization;

namespace COVID19_UpdatesWebAPI.Net6.Services
{
    public class COVID19UpdatesService : ICOVID19UpdatesService
    {
        #region Get COVID19 Updates
        public List<COVID19UpdatesVM> GetCOVID19Cases(string? country, string? state, DateTime lastUpdatedDate)
        {

            List<COVID19UpdatesVM> covidUpdateList = new List<COVID19UpdatesVM>();

            List<string> fpaths = ReadFiles();
            if (fpaths.Count > 0 && fpaths != null)
            {
                List<string> jsondata = ConvertCsvFileToJsonObject(fpaths);

                if (jsondata.Count > 0 && jsondata != null)
                {
                    List<COVID19Updates> DeserializedJObj = DeserializeJsonObject(jsondata);

                    if (DeserializedJObj.Count > 0 && DeserializedJObj != null)
                    {

                        if (lastUpdatedDate == DateTime.MinValue)

                            covidUpdateList = DeserializedJObj.ToList()
                           .Where(a => a.Country_Region == (!String.IsNullOrEmpty(country) ? country : a.Country_Region) && a.Province_State == (!String.IsNullOrEmpty(state) ? state : a.Province_State)
                           )
                           .Select(x => new COVID19UpdatesVM
                           {
                               Country_Region = x.Country_Region,
                               Province_State = x.Province_State,
                               Confirmed = x.Confirmed,
                               Deaths = x.Deaths,
                               Recovered = x.Recovered,
                               Active = x.Active,
                               LastUpdatedDate = x.LastUpdatedDate
                           }).OrderBy(x => x.LastUpdatedDate).ToList();

                        else
                            covidUpdateList = DeserializedJObj.ToList()
                              .Where(a => a.Country_Region == (!String.IsNullOrEmpty(country) ? country : a.Country_Region) && a.Province_State == (!String.IsNullOrEmpty(state) ? state : a.Province_State)
                               && a.LastUpdatedDate.Date >= lastUpdatedDate.Date && a.LastUpdatedDate.Date <= lastUpdatedDate.Date
                              )
                              .Select(x => new COVID19UpdatesVM
                              {
                                  Country_Region = x.Country_Region,
                                  Province_State = x.Province_State,
                                  Confirmed = x.Confirmed,
                                  Deaths = x.Deaths,
                                  Recovered = x.Recovered,
                                  Active = x.Active,
                                  LastUpdatedDate = x.LastUpdatedDate
                              }).OrderBy(x => x.LastUpdatedDate).ToList();
                    }

                }
            }
            return covidUpdateList;
        }

        #endregion 

        #region Method Implementation
        public List<COVID19Updates> DeserializeJsonObject(List<string> jsondata)
        {
            List<COVID19Updates> DeserializedJObj = new List<COVID19Updates>();

            foreach (string JObj in jsondata)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<COVID19Updates>>(JObj);
                foreach (var plan in myDeserializedClass)
                {
                    var selectedList = new COVID19Updates
                    {
                        FIPS = plan.FIPS,
                        Admin2 = plan.Admin2,
                        Province_State = plan.Province_State,
                        Country_Region = plan.Country_Region,
                        Last_Update = plan.Last_Update,
                        Lat = plan.Lat,
                        Long_ = plan.Long_,
                        Confirmed = plan.Confirmed,
                        Deaths = plan.Deaths,
                        Recovered = plan.Recovered,
                        Active = plan.Active,
                        Combined_Key = plan.Combined_Key,
                        Incident_Rate = plan.Incident_Rate,
                        Case_Fatality_Ratio = plan.Case_Fatality_Ratio,
                        LastUpdatedDate = ConvertStringDateToDatime(plan.Last_Update),
                    };
                    DeserializedJObj.Add(selectedList);
                }
            }

            return DeserializedJObj;
        }

        private DateTime ConvertStringDateToDatime(string _lastUpdatedDate)
        {
            DateTime LastUpdatedDate = new DateTime();
            if (_lastUpdatedDate.Any(char.IsDigit))
                LastUpdatedDate = DateTime.ParseExact(_lastUpdatedDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            return LastUpdatedDate;
        }

        public List<string> ConvertCsvFileToJsonObject(List<string> fpaths)
        {
            List<string> jsondata = new List<string>();

            foreach (var fpath in fpaths)
            {
                var csv = new List<string[]>();
                var lines = File.ReadAllLines(fpath);

                foreach (string line in lines)
                    csv.Add(line.Split(','));

                var properties = lines[0].Split(',');

                var listObjResult = new List<Dictionary<string, string>>();

                for (int i = 1; i < lines.Length; i++)
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                        objResult.Add(properties[j], csv[i][j]);

                    listObjResult.Add(objResult);
                }
                var JObj = JsonConvert.SerializeObject(listObjResult);
                jsondata.Add(JObj);

            }

            return jsondata;

        }

        private List<string> ReadFiles()
        {
            var folderRootPath = GetFilePath();
            // in the future> read files from the ftp or database or git path 
            var csvFiles = new DirectoryInfo(folderRootPath).GetFiles("*.csv");
            List<string> fileList = new List<string>();
            foreach (var fname in csvFiles)
            {
                string fFullPath = folderRootPath + "\\" + fname.Name;

                fileList.Add(fFullPath);
            }

            return fileList;
        }

        public string GetFilePath()
        {

            string folderName = @"Models\\Data";
            string folderRootPath = Path.GetFullPath(folderName);

            if (folderRootPath.Contains("XUnitTest"))
            {
                folderName = "COVID19-UpdatesWebAPI.Net6\\Models\\Data";
                string rootPath = folderRootPath.Replace("COVID19-UpdatesWebAPI.Net6.XUnitTest\\bin\\Debug\\net6.0\\Models\\Data", string.Empty);
                folderRootPath = rootPath + folderName;
            }

            return folderRootPath;
        }

        #endregion

    }
}
