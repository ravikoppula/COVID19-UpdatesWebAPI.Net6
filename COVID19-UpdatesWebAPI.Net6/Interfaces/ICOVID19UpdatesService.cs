namespace COVID19_UpdatesWebAPI.Net6
{
    public interface ICOVID19UpdatesService
    {
        #region IGet

        List<COVID19UpdatesVM> GetCOVID19Cases(string? country, string? state, DateTime lastUpdatedDate);

        #endregion
    }
}
