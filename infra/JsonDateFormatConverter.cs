using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

//Este é um conversor personalizado de datas em JSON. Ele permite a leitura e escrita de datas no formato "yyyy-MM-dd" ou no formato ISO 8601 "yyyy-MM-ddTHH:mm:ss.fffZ" para datas em objetos JSON. Ele é útil para garantir que as datas sejam serializadas e desserializadas conforme necessário em sua aplicação.


public class JsonDateFormatConverter : JsonConverter<DateTime>
{

    //Read: Este método lê o valor do JSON e tenta analisá-lo como uma data no formato "yyyy-MM-dd" ou no formato ISO 8601 "yyyy-MM-ddTHH:mm:ss.fffZ". Se a análise for bem-sucedida, ele retorna a data; caso contrário, retorna DateTime.MinValue
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var data))
        {
            return data;
        }
        else if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var isoDate))
        {
            return isoDate;
        }
        return DateTime.MinValue;
    }

    
   // Write: Este método escreve uma data no formato "yyyy-MM-dd" no JSON
   

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
