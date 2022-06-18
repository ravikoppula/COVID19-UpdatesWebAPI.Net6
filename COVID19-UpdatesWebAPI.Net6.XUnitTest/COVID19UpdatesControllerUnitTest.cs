using COVID19_UpdatesWebAPI.Net6.Services;

namespace COVID19_UpdatesWebAPI.Net6.XUnitTest
{
    public class COVID19UpdatesControllerUnitTest
    {
        #region Declarations

        private COVID19UpdatesService? _unitTesting = null;

        public COVID19UpdatesControllerUnitTest()
        {
            _unitTesting = new COVID19UpdatesService();
        }

        string country = string.Empty;
        string state = string.Empty;
        DateTime lastUpdate = new DateTime();

        #endregion

        #region Test Methods

        [Fact]
        public void GetAllCountriesUpdate()
        {
            // Arrange

            // Act
            var result = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            // Assert
            Assert.True(result.Count > 0);

        }

        [Fact]
        public void FilterByCountry()
        {
            // Arrange
            country = "Canada";

            // Act
            var _response = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            bool response = _response.TrueForAll(_ => _.Country_Region == country);

            // Assert
            Assert.True(response);

        }

        [Fact]
        public void FilterByState()
        {
            // Arrange
            state = "Ontario";

            // Act
            var _response = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            bool response = _response.TrueForAll(_ => _.Province_State == state);

            // Assert
            Assert.True(response);

        }

        [Fact]
        public void FilterByDate()
        {
            // Arrange
            lastUpdate = Convert.ToDateTime("2021-01-02");

            // Act
            var _response = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            bool response = _response.TrueForAll(_ => _.LastUpdatedDate.Date == lastUpdate);

            // Assert
            Assert.True(response);

        }

        [Fact]
        public void AllFilters()
        {
            // Arrange
            country = "Canada";
            state = "Ontario";
            lastUpdate = Convert.ToDateTime("2021-01-02");

            // Act
            var _response = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            bool response = _response.TrueForAll(_ => _.Country_Region == country && _.Province_State == state && _.LastUpdatedDate.Date == lastUpdate);

            // Assert
            Assert.True(response);

        }

        [Theory]
        [ClassData(typeof(TestInputData))]
        public void FilterByCountries(string country, string state, DateTime lastUpdate)
        {
            var result = _unitTesting.GetCOVID19Cases(country, state, lastUpdate);

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ConvertCsvFileToJsonObjectTest()
        {
            List<string> fPath = new List<string>();

            string folderPath = _unitTesting.GetFilePath();

            fPath.Add(folderPath + "\\01-01-2021.csv");
            var jsondata = _unitTesting.ConvertCsvFileToJsonObject(fPath);

            Assert.True(jsondata.Count > 0);

        }

        #endregion 

    }
}