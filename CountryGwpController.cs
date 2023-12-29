using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("api/gwp")]
    public class CountryGwpController : ControllerBase
    {
        private readonly string _csvFilePath = @"C:\Users\Shreya Sharma\Downloads\BE exercise\Galytix.WebApi (4)\Data\gwpByCountry.csv";

        [HttpPost("avg")]
        public async Task<ActionResult<IDictionary<string, decimal>>> GetAverageGwpByLineOfBusiness([FromBody] GwpRequest request)
        {
            try
            {
                var gwpData = await ReadCsvAsync(_csvFilePath);

                var result = new Dictionary<string, decimal>();

                foreach (var lob in request.lob)
                {
                    var averageGwp = gwpData
                        .Where(entry => entry.country.ToLower() == request.country.ToLower() && entry.lineOfBusiness.ToLower() == lob.ToLower())
                        .Average(entry => entry.GetGwpForYear(request.year));

                    result.Add(lob.ToLower(), averageGwp);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private async Task<List<GwpEntry>> ReadCsvAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {

                return await Task.Run(() => csv.GetRecords<GwpEntry>().ToList());
            }
        }
    }
    public class GwpRequest
    {
        public string country { get; set; }
        public List<string> lob { get; set; }
        public int year { get; set; }
    }

    public class GwpEntry
    {
        public string country { get; set; }
        public string variableId { get; set; }
        public string variableName { get; set; }
        public string lineOfBusiness { get; set; }
        public decimal? Y2000 { get; set; }
        public decimal? Y2001 { get; set; }
        public decimal? Y2002 { get; set; }
        public decimal? Y2003 { get; set; }
        public decimal? Y2004 { get; set; }
        public decimal? Y2005 { get; set; }
        public decimal? Y2006 { get; set; }
        public decimal? Y2007 { get; set; }
        public decimal? Y2008 { get; set; }
        public decimal? Y2009 { get; set; }
        public decimal? Y2010 { get; set; }
        public decimal? Y2011 { get; set; }
        public decimal? Y2012 { get; set; }
        public decimal? Y2013 { get; set; }
        public decimal? Y2014 { get; set; }
        public decimal? Y2015 { get; set; }

        public decimal GetGwpForYear(int year)
        {
            // Dynamically get the GWP for the specified year
            var propertyName = $"Y{year}";
            var property = GetType().GetProperty(propertyName);
            return (decimal)(property?.GetValue(this) ?? 0m);
        }
    }
}

