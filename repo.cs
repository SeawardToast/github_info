using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace WebAPIClient
{
    [DataContract(Name="repo")] //for JSON
    public class Repository
    {
        [DataMember(Name="name")] //for JSON
	public string Name {get; set; }

	[DataMember(Name="description")]
	public string Description { get; set; }

	[DataMember(Name="html_url")]
	public Uri GitHubHomeUrl { get; set; }

	[DataMember(Name="homepage")]
	public Uri Homepage { get; set; }

	[DataMember(Name="watchers")]
	public int Watchers { get; set; }

	[DataMember(Name="pushed_at")]
	private string JsonDate { get; set; }

	[IgnoreDataMember] //don't read or write to from any JSON object
	public DateTime LastPush
	{
	    get
	    {
	        return DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);

	    }
	}

    }


}
