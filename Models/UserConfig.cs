﻿namespace CarCareTracker.Models
{
    public class UserConfig
    {
        public bool UseDarkMode { get; set; }
        public bool UseSystemColorMode { get; set; }
        public bool EnableCsvImports { get; set; }
        public bool UseMPG { get; set; }
        public bool UseDescending { get; set; }
        public bool EnableAuth { get; set; }
        public bool DisableRegistration { get; set; }
        public bool EnableRootUserOIDC { get; set; }
        public bool HideZero { get; set; }
        public bool UseUKMPG {get;set;}
        public bool HideOdometerTags { get; set; }
        public bool UseThreeDecimalGasCost { get; set; }
        public bool UseMarkDownOnSavedNotes { get; set; }
        public bool EnableAutoReminderRefresh { get; set; }
        public bool EnableAutoOdometerInsert { get; set; }
        public bool EnableShopSupplies { get; set; }
        public bool EnableExtraFieldColumns { get; set; }
        public bool HideSoldVehicles { get; set; }
        public string PreferredGasUnit { get; set; } = string.Empty;
        public string PreferredGasMileageUnit { get; set; } = string.Empty;
        public List<UserColumnPreference> UserColumnPreferences { get; set; } = new List<UserColumnPreference>();
        public ReminderUrgencyConfig ReminderUrgencyConfig { get; set; } = new ReminderUrgencyConfig();
        public string UserNameHash { get; set; }
        public string UserPasswordHash { get; set;}
        public string DefaultReminderEmail { get; set; } = string.Empty;
        public string UserLanguage { get; set; } = "en_US";
        public List<ImportMode> VisibleTabs { get; set; } = new List<ImportMode>() { 
            ImportMode.Dashboard,
            ImportMode.ServiceRecord, 
            ImportMode.RepairRecord, 
            ImportMode.GasRecord, 
            ImportMode.UpgradeRecord, 
            ImportMode.TaxRecord, 
            ImportMode.ReminderRecord, 
            ImportMode.NoteRecord};
        public ImportMode DefaultTab { get; set; } = ImportMode.Dashboard;
    }
}