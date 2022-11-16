using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Teste_ControleDeCinema.Webapi.Filters;

namespace Teste_ControleDeCinema.Webapi.Config
{
    public static class FiltersConfig 
    {
        public static void ConfigurarFiltros(this IServiceCollection services)
        {
            services
                .AddControllers(config => { config.Filters.Add(new ValidarViewModelActionFilter()); })
                .AddJsonOptions(opt => {
                    opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter());
                    opt.JsonSerializerOptions.Converters.Add(new ConverterImagem());
                    });
                
        }
    }

    public class TimeSpanToStringConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }


}
