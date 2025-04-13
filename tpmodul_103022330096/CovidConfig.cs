using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tpmodul_103022330096
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string configFile = "covid_config.json";

        public static CovidConfig LoadConfig()
        {
            if (!File.Exists(configFile))
            {
                CovidConfig defaultConfig = new CovidConfig
                {
                    satuan_suhu = "celsius",
                    batas_hari_demam = 14,
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan masuk ke dalam gedung ini"
                };

                string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFile, json);
                return defaultConfig;
            } else
            {
                string json = File.ReadAllText(configFile);
                return JsonSerializer.Deserialize<CovidConfig>(json);
            }
        }

        public void ubahSatuan()
        {
            if (satuan_suhu == "celsius")
            {
                satuan_suhu = "fahrenheit";
            } else
            {
                satuan_suhu = "celsius";
            }
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);
        }
    }
}
