﻿using CarCareTracker.Models;
using CsvHelper;
using System.Globalization;

namespace CarCareTracker.Helper
{
    /// <summary>
    /// helper method for static vars
    /// </summary>
    public static class StaticHelper
    {
        public static string VersionNumber = "1.3.9";
        public static string DbName = "data/cartracker.db";
        public static string UserConfigPath = "config/userConfig.json";
        public static string GenericErrorMessage = "An error occurred, please try again later";
        public static string ReminderEmailTemplate = "defaults/reminderemailtemplate.txt";
        public static string DefaultAllowedFileExtensions = ".png,.jpg,.jpeg,.pdf,.xls,.xlsx,.docx";
        public static string SponsorsPath = "https://hargata.github.io/hargata/sponsors.json";
        public static string GetTitleCaseReminderUrgency(ReminderUrgency input)
        {
            switch (input)
            {
                case ReminderUrgency.NotUrgent:
                    return "Not Urgent";
                case ReminderUrgency.VeryUrgent:
                    return "Very Urgent";
                case ReminderUrgency.PastDue:
                    return "Past Due";
                default:
                    return input.ToString();
            }
        }

        public static string TruncateStrings(string input, int maxLength = 25)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            if (input.Length > maxLength)
            {
                return (input.Substring(0, maxLength) + "...");
            }
            else
            {
                return input;
            }
        }
        public static string DefaultActiveTab(UserConfig userConfig, ImportMode tab)
        {
            var defaultTab = userConfig.DefaultTab;
            var visibleTabs = userConfig.VisibleTabs;
            if (visibleTabs.Contains(tab) && tab == defaultTab)
            {
                return "active";
            }
            else if (!visibleTabs.Contains(tab))
            {
                return "d-none";
            }
            return "";
        }
        public static string DefaultActiveTabContent(UserConfig userConfig, ImportMode tab)
        {
            var defaultTab = userConfig.DefaultTab;
            if (tab == defaultTab)
            {
                return "show active";
            }
            return "";
        }
        public static string DefaultTabSelected(UserConfig userConfig, ImportMode tab)
        {
            var defaultTab = userConfig.DefaultTab;
            var visibleTabs = userConfig.VisibleTabs;
            if (!visibleTabs.Contains(tab))
            {
                return "disabled";
            }
            else if (tab == defaultTab)
            {
                return "selected";
            }
            return "";
        }
        public static List<CostForVehicleByMonth> GetBaseLineCosts()
        {
            return new List<CostForVehicleByMonth>()
            {
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1), MonthId = 1, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(2), MonthId = 2, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(3), MonthId = 3, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(4), MonthId = 4, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(5), MonthId = 5, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(6), MonthId = 6, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(7), MonthId = 7, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8), MonthId = 8, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(9), MonthId = 9, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(10), MonthId = 10, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(11), MonthId = 11, Cost = 0M},
                new CostForVehicleByMonth {MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(12), MonthId = 12, Cost = 0M}
            };
        }
        public static List<CostForVehicleByMonth> GetBaseLineCostsNoMonthName()
        {
            return new List<CostForVehicleByMonth>()
            {
                new CostForVehicleByMonth { MonthId = 1, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 2, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 3, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 4, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 5, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 6, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 7, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 8, Cost = 0M},
                new CostForVehicleByMonth {MonthId = 9, Cost = 0M},
                new CostForVehicleByMonth { MonthId = 10, Cost = 0M},
                new CostForVehicleByMonth { MonthId = 11, Cost = 0M},
                new CostForVehicleByMonth { MonthId = 12, Cost = 0M}
            };
        }

        public static ServiceRecord GenericToServiceRecord(GenericRecord input)
        {
            return new ServiceRecord
            {
                VehicleId = input.VehicleId,
                Date = input.Date,
                Description = input.Description,
                Cost = input.Cost,
                Mileage = input.Mileage,
                Files = input.Files,
                Notes = input.Notes,
                Tags = input.Tags,
                ExtraFields = input.ExtraFields,
                RequisitionHistory = input.RequisitionHistory
            };
        }
        public static CollisionRecord GenericToRepairRecord(GenericRecord input)
        {
            return new CollisionRecord
            {
                VehicleId = input.VehicleId,
                Date = input.Date,
                Description = input.Description,
                Cost = input.Cost,
                Mileage = input.Mileage,
                Files = input.Files,
                Notes = input.Notes,
                Tags = input.Tags,
                ExtraFields = input.ExtraFields,
                RequisitionHistory = input.RequisitionHistory
            };
        }
        public static UpgradeRecord GenericToUpgradeRecord(GenericRecord input)
        {
            return new UpgradeRecord
            {
                VehicleId = input.VehicleId,
                Date = input.Date,
                Description = input.Description,
                Cost = input.Cost,
                Mileage = input.Mileage,
                Files = input.Files,
                Notes = input.Notes,
                Tags = input.Tags,
                ExtraFields = input.ExtraFields,
                RequisitionHistory = input.RequisitionHistory
            };
        }

        public static List<ExtraField> AddExtraFields(List<ExtraField> recordExtraFields, List<ExtraField> templateExtraFields)
        {
            if (!templateExtraFields.Any()) {
                return new List<ExtraField>();
            }
            if (!recordExtraFields.Any())
            {
                return templateExtraFields;
            }
            var fieldNames = templateExtraFields.Select(x => x.Name);
            //remove fields that are no longer present in template.
            recordExtraFields.RemoveAll(x => !fieldNames.Contains(x.Name));
            if (!recordExtraFields.Any())
            {
                return templateExtraFields;
            }
            var recordFieldNames = recordExtraFields.Select(x => x.Name);
            //update isrequired setting
            foreach (ExtraField extraField in recordExtraFields)
            {
                extraField.IsRequired = templateExtraFields.Where(x => x.Name == extraField.Name).First().IsRequired;
            }
            //append extra fields
            foreach(ExtraField extraField in templateExtraFields)
            {
                if (!recordFieldNames.Contains(extraField.Name))
                {
                    recordExtraFields.Add(extraField);
                }
            }
            return recordExtraFields;
        }

        public static string GetFuelEconomyUnit(bool useKwh, bool useHours, bool useMPG, bool useUKMPG)
        {
            string fuelEconomyUnit;
            if (useKwh)
            {
                var distanceUnit = useHours ? "h" : (useMPG ? "mi." : "km");
                fuelEconomyUnit = useMPG ? $"{distanceUnit}/kWh" : $"kWh/100{distanceUnit}";
            }
            else if (useMPG && useUKMPG)
            {
                fuelEconomyUnit = useHours ? "h/g" : "mpg";
            }
            else if (useUKMPG)
            {
                fuelEconomyUnit = useHours ? "l/100h" : "l/100mi.";
            }
            else
            {
                fuelEconomyUnit = useHours ? (useMPG ? "h/g" : "l/100h") : (useMPG ? "mpg" : "l/100km");
            }
            return fuelEconomyUnit;
        }
        public static long GetEpochFromDateTime(DateTime date)
        {
            return new DateTimeOffset(date).ToUnixTimeMilliseconds();
        }
        public static void InitMessage(IConfiguration config)
        {
            Console.WriteLine($"LubeLogger {VersionNumber}");
            Console.WriteLine("Website: https://lubelogger.com");
            Console.WriteLine("Documentation: https://docs.lubelogger.com");
            Console.WriteLine("GitHub: https://github.com/hargata/lubelog");
            var mailConfig = config.GetSection("MailConfig").Get<MailConfig>();
            if (mailConfig != null && !string.IsNullOrWhiteSpace(mailConfig.EmailServer))
            {
                Console.WriteLine($"SMTP Configured for {mailConfig.EmailServer}");
            } else
            {
                Console.WriteLine("SMTP Not Configured");
            }
            var motd = config["LUBELOGGER_MOTD"] ?? "Not Configured";
            Console.WriteLine($"Message Of The Day: {motd}");
            if (string.IsNullOrWhiteSpace(CultureInfo.CurrentCulture.Name))
            {
                Console.WriteLine("No Locale or Culture Configured for LubeLogger, Check Environment Variables");
            }
        }
        public static async void NotifyAsync(string webhookURL, int vehicleId, string username, string action)
        {
            if (string.IsNullOrWhiteSpace(webhookURL))
            {
                return;
            }
            var httpClient = new HttpClient();
            var httpParams = new Dictionary<string, string>
                {
                { "vehicleId", vehicleId.ToString() },
                     { "username", username },
                     { "action", action },
                };
            httpClient.PostAsJsonAsync(webhookURL, httpParams);
        }
        public static string GetImportModeIcon(ImportMode importMode)
        {
            switch (importMode)
            {
                case ImportMode.ServiceRecord:
                    return "bi-card-checklist";
                case ImportMode.RepairRecord:
                    return "bi-exclamation-octagon";
                case ImportMode.UpgradeRecord:
                    return "bi-wrench-adjustable";
                case ImportMode.TaxRecord:
                    return "bi-currency-dollar";
                case ImportMode.SupplyRecord:
                    return "bi-shop";
                case ImportMode.PlanRecord:
                    return "bi-bar-chart-steps";
                case ImportMode.OdometerRecord:
                    return "bi-speedometer";
                case ImportMode.GasRecord:
                    return "bi-fuel-pump";
                case ImportMode.NoteRecord:
                    return "bi-journal-bookmark";
                case ImportMode.ReminderRecord:
                    return "bi-bell";
                default:
                    return "bi-file-bar-graph";
            }
        }
        //CSV Write Methods
        public static void WriteGenericRecordExportModel(CsvWriter _csv, IEnumerable<GenericRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(GenericRecordExportModel.Date));
            _csv.WriteField(nameof(GenericRecordExportModel.Description));
            _csv.WriteField(nameof(GenericRecordExportModel.Cost));
            _csv.WriteField(nameof(GenericRecordExportModel.Notes));
            _csv.WriteField(nameof(GenericRecordExportModel.Odometer));
            _csv.WriteField(nameof(GenericRecordExportModel.Tags));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (GenericRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.Date);
                _csv.WriteField(genericRecord.Description);
                _csv.WriteField(genericRecord.Cost);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Odometer);
                _csv.WriteField(genericRecord.Tags);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
        public static void WriteOdometerRecordExportModel(CsvWriter _csv, IEnumerable<OdometerRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(OdometerRecordExportModel.Date));
            _csv.WriteField(nameof(OdometerRecordExportModel.InitialOdometer));
            _csv.WriteField(nameof(OdometerRecordExportModel.Odometer));
            _csv.WriteField(nameof(OdometerRecordExportModel.Notes));
            _csv.WriteField(nameof(OdometerRecordExportModel.Tags));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (OdometerRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.Date);
                _csv.WriteField(genericRecord.InitialOdometer);
                _csv.WriteField(genericRecord.Odometer);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Tags);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
        public static void WriteTaxRecordExportModel(CsvWriter _csv, IEnumerable<TaxRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(TaxRecordExportModel.Date));
            _csv.WriteField(nameof(TaxRecordExportModel.Description));
            _csv.WriteField(nameof(TaxRecordExportModel.Cost));
            _csv.WriteField(nameof(TaxRecordExportModel.Notes));
            _csv.WriteField(nameof(TaxRecordExportModel.Tags));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (TaxRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.Date);
                _csv.WriteField(genericRecord.Description);
                _csv.WriteField(genericRecord.Cost);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Tags);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
        public static void WriteSupplyRecordExportModel(CsvWriter _csv, IEnumerable<SupplyRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(SupplyRecordExportModel.Date));
            _csv.WriteField(nameof(SupplyRecordExportModel.PartNumber));
            _csv.WriteField(nameof(SupplyRecordExportModel.PartSupplier));
            _csv.WriteField(nameof(SupplyRecordExportModel.PartQuantity));
            _csv.WriteField(nameof(SupplyRecordExportModel.Description));
            _csv.WriteField(nameof(SupplyRecordExportModel.Notes));
            _csv.WriteField(nameof(SupplyRecordExportModel.Cost));
            _csv.WriteField(nameof(SupplyRecordExportModel.Tags));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (SupplyRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.Date);
                _csv.WriteField(genericRecord.PartNumber);
                _csv.WriteField(genericRecord.PartSupplier);
                _csv.WriteField(genericRecord.PartQuantity);
                _csv.WriteField(genericRecord.Description);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Cost);
                _csv.WriteField(genericRecord.Tags);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
        public static void WritePlanRecordExportModel(CsvWriter _csv, IEnumerable<PlanRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(PlanRecordExportModel.DateCreated));
            _csv.WriteField(nameof(PlanRecordExportModel.DateModified));
            _csv.WriteField(nameof(PlanRecordExportModel.Description));
            _csv.WriteField(nameof(PlanRecordExportModel.Notes));
            _csv.WriteField(nameof(PlanRecordExportModel.Type));
            _csv.WriteField(nameof(PlanRecordExportModel.Priority));
            _csv.WriteField(nameof(PlanRecordExportModel.Progress));
            _csv.WriteField(nameof(PlanRecordExportModel.Cost));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (PlanRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.DateCreated);
                _csv.WriteField(genericRecord.DateModified);
                _csv.WriteField(genericRecord.Description);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Type);
                _csv.WriteField(genericRecord.Priority);
                _csv.WriteField(genericRecord.Progress);
                _csv.WriteField(genericRecord.Cost);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
        public static void WriteGasRecordExportModel(CsvWriter _csv, IEnumerable<GasRecordExportModel> genericRecords)
        {
            var extraHeaders = genericRecords.SelectMany(x => x.ExtraFields).Select(y => y.Name).Distinct();
            //write headers
            _csv.WriteField(nameof(GasRecordExportModel.Date));
            _csv.WriteField(nameof(GasRecordExportModel.Odometer));
            _csv.WriteField(nameof(GasRecordExportModel.FuelConsumed));
            _csv.WriteField(nameof(GasRecordExportModel.Cost));
            _csv.WriteField(nameof(GasRecordExportModel.FuelEconomy));
            _csv.WriteField(nameof(GasRecordExportModel.IsFillToFull));
            _csv.WriteField(nameof(GasRecordExportModel.MissedFuelUp));
            _csv.WriteField(nameof(GasRecordExportModel.Notes));
            _csv.WriteField(nameof(GasRecordExportModel.Tags));
            foreach (string extraHeader in extraHeaders)
            {
                _csv.WriteField($"extrafield_{extraHeader}");
            }
            _csv.NextRecord();
            foreach (GasRecordExportModel genericRecord in genericRecords)
            {
                _csv.WriteField(genericRecord.Date);
                _csv.WriteField(genericRecord.Odometer);
                _csv.WriteField(genericRecord.FuelConsumed);
                _csv.WriteField(genericRecord.Cost);
                _csv.WriteField(genericRecord.FuelEconomy);
                _csv.WriteField(genericRecord.IsFillToFull);
                _csv.WriteField(genericRecord.MissedFuelUp);
                _csv.WriteField(genericRecord.Notes);
                _csv.WriteField(genericRecord.Tags);
                foreach (string extraHeader in extraHeaders)
                {
                    var extraField = genericRecord.ExtraFields.Where(x => x.Name == extraHeader).FirstOrDefault();
                    _csv.WriteField(extraField != null ? extraField.Value : string.Empty);
                }
                _csv.NextRecord();
            }
        }
    }
}
