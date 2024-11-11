using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.WeatherDtos
{
    
        public class AccuWeatherRootDto
        {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }

        }



        public class DailyForecastsDto
        {
            [JsonPropertyName("Date")]
            public string Date { get; set; }

            [JsonPropertyName("EpochDate")]
            public int EpochDate { get; set; }

            [JsonPropertyName("Temperature")]
            public Temperature Temperature { get; set; }

            [JsonPropertyName("Day")]
            public Day Day { get; set; }

            [JsonPropertyName("Night")]
            public Night Night { get; set; }

            [JsonPropertyName("Sources")]
            public List<string> Sources { get; set; }

            [JsonPropertyName("MobileLink")]
            public string MobileLink { get; set; }

            [JsonPropertyName("Link")]
            public string Link { get; set; }
        }

        public class Day
        {
            [JsonPropertyName("Icon")]
            public int Icon { get; set; }

            [JsonPropertyName("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonPropertyName("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }
        }

        public class HeadlineDto
        {
            [JsonPropertyName("EffectiveDate")]
            public string EffectiveDate { get; set; }

            [JsonPropertyName("EffectiveEpochDate")]
            public int EffectiveEpochDate { get; set; }

            [JsonPropertyName("Severity")]
            public int Severity { get; set; }

            [JsonPropertyName("Text")]
            public string Text { get; set; }

            [JsonPropertyName("Category")]
            public string Category { get; set; }

            [JsonPropertyName("EndDate")]
            public string EndDate { get; set; }

            [JsonPropertyName("EndEpochDate")]
            public int EndEpochDate { get; set; }

            [JsonPropertyName("MobileLink")]
            public string MobileLink { get; set; }

            [JsonPropertyName("Link")]
            public string Link { get; set; }
        }

        public class Maximum
        {
            [JsonPropertyName("Value")]
            public double Value { get; set; }

            [JsonPropertyName("Unit")]
            public string Unit { get; set; }

            [JsonPropertyName("UnitType")]
            public int UnitType { get; set; }
        }

        public class Minimum
        {
            [JsonPropertyName("Value")]
            public double Value { get; set; }

            [JsonPropertyName("Unit")]
            public string Unit { get; set; }

            [JsonPropertyName("UnitType")]
            public int UnitType { get; set; }
        }

        public class Night
        {
            [JsonPropertyName("Icon")]
            public int Icon { get; set; }

            [JsonPropertyName("IconPhrase")]
            public string IconPhrase { get; set; }

            [JsonPropertyName("HasPrecipitation")]
            public bool HasPrecipitation { get; set; }
        }



        public class Temperature
        {
            [JsonPropertyName("Minimum")]
            public Minimum Minimum { get; set; }

            [JsonPropertyName("Maximum")]
            public Maximum Maximum { get; set; }
        }

    
}
