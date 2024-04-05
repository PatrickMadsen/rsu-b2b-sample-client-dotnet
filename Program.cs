using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

// test cvr 41250313

namespace UFSTWSSecuritySample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            Settings settings = configuration.GetSection("Settings").Get<Settings>();
            Endpoints endpoints = configuration.GetSection("Endpoints").Get<Endpoints>();

            if (!File.Exists(settings.PathPKCS12))
            {
                Console.WriteLine("Cannot find " + settings.PathPKCS12);
                Console.WriteLine("Aborting run...");
                return;
            }

            if (!File.Exists(settings.PathPEM))
            {
                Console.WriteLine("Cannot find " + settings.PathPEM);
                Console.WriteLine("Aborting run...");
                return;
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            string jsonString = args[0];
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            var command = data["command"].ToString();

            IApiClient client = new ApiClient(settings);

            var Angivelsesafgifter = new System.Collections.Generic.Dictionary<string, string>();
            Angivelsesafgifter.Add("MomsAngivelseAfgiftTilsvarBeloeb", data["MomsAngivelseAfgiftTilsvarBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseCO2AfgiftBeloeb", data["MomsAngivelseCO2AfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseEUKoebBeloeb", data["MomsAngivelseEUKoebBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseEUSalgBeloebVarerBeloeb", data["MomsAngivelseEUSalgBeloebVarerBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseIkkeEUSalgBeloebVarerBeloeb", data["MomsAngivelseIkkeEUSalgBeloebVarerBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseElAfgiftBeloeb", data["MomsAngivelseElAfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseEksportOmsaetningBeloeb", data["MomsAngivelseEksportOmsaetningBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseGasAfgiftBeloeb", data["MomsAngivelseGasAfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseKoebsMomsBeloeb", data["MomsAngivelseKoebsMomsBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseKulAfgiftBeloeb", data["MomsAngivelseKulAfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseMomsEUKoebBeloeb", data["MomsAngivelseMomsEUKoebBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseMomsEUYdelserBeloeb", data["MomsAngivelseMomsEUYdelserBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseOlieAfgiftBeloeb", data["MomsAngivelseOlieAfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseSalgsMomsBeloeb", data["MomsAngivelseSalgsMomsBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseVandAfgiftBeloeb", data["MomsAngivelseVandAfgiftBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseEUKoebYdelseBeloeb", data["MomsAngivelseEUKoebYdelseBeloeb"].ToString());
            Angivelsesafgifter.Add("MomsAngivelseEUSalgYdelseBeloeb", data["MomsAngivelseEUSalgYdelseBeloeb"].ToString());

            switch (command)
            {
                case "VirksomhedKalenderHent":
                    var res = await client.CallService(new VirksomhedKalenderHentWriter(data["cvr"].ToString(), data["dateFrom"].ToString(), data["dateTo"].ToString()), endpoints.VirksomhedKalenderHent);
                    Console.WriteLine(res);
                    break;
                case "ModtagMomsangivelseForeloebig":
                    var res2 = await client.CallService(new ModtagMomsangivelseForeloebigWriter(data["cvr"].ToString(), data["dateFrom"].ToString(), data["dateTo"].ToString(), Angivelsesafgifter), endpoints.ModtagMomsangivelseForeloebig);
                    Console.WriteLine(res2);
                    break;
                case "MomsangivelseKvitteringHent":
                    var res3 = await client.CallService(new MomsangivelseKvitteringHentWriter(data["cvr"].ToString(), data["transaktionIdentifier"].ToString()), endpoints.MomsangivelseKvitteringHent);
                    Console.WriteLine(res3);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("dotnet run json.obj");
                    break;
            }
        }
    }
}
